using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.DTO;
using TodoApp.Models;

namespace TodoApp.Map
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Tasks, TasksDTO>().ForMember(s=>s.Employee,opt=>opt.MapFrom(src=>src.Employees.FullName)); 
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
        
    }
}
