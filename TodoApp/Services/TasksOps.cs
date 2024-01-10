using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Contracts;
using TodoApp.Data;
using TodoApp.DTO;
using TodoApp.Models;

namespace TodoApp.Services
{
    public class TasksOps : ITasksOps
    {
        private readonly ApplicationDbContext applicationDb;
        private readonly IMapper mapper;

        public TasksOps(ApplicationDbContext applicationDb, IMapper mapper)
        {
            this.applicationDb = applicationDb;
            this.mapper = mapper;
        }
        public async Task<TasksDTO> Create(TasksDTO entity)
        {
            var tasks = this.mapper.Map<Tasks>(entity);
            await this.applicationDb.AddAsync(tasks);
            await Save();
            return entity;
        }

        public async Task<bool> Delete(TasksDTO entity)
        {
            var tasks = this.mapper.Map<Tasks>(entity);
            this.applicationDb.Remove(tasks);
            var isSuccess = await Save();
            return isSuccess;
        }

        public async Task<IList<TasksDTO>> FindAll()
        {
            var tasks =  this.applicationDb.Tasks.Include(x=>x.Employees).ToList();
            var data = this.mapper.Map<IList<TasksDTO>>(tasks);
           
            return data;
        }

        public async Task<TasksDTO> FindById(int id)
        {
            var tasks = this.applicationDb.Tasks.Where(x=>x.TaskID == id).FirstOrDefault();
            var data =  this.mapper.Map<TasksDTO>(tasks);    
           
            return this.mapper.Map<TasksDTO>(tasks);
        }

        public Task<TasksDTO> FindBystring(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmployeeDTO>> getAllEmp()
        {
            var emps = this.applicationDb.Employee.ToList();
            return this.mapper.Map<List<EmployeeDTO>>(emps);
        }

        public async Task<bool> isExists(int id)
        {
            return this.applicationDb.Tasks.Any(x => x.TaskID == id);
        }

        public async Task<bool> Save()
        {
          var result = await this.applicationDb.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> Update(TasksDTO entity)
        {
            var tasks = this.mapper.Map<Tasks>(entity);
            this.applicationDb.Update(tasks);
            var isSuccess = await Save();
            return isSuccess;
        }
    }
}
