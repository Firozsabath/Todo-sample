using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.DTO;

namespace TodoApp.Contracts
{
    public interface ITasksOps:IRepositoryBase<TasksDTO>
    {
        Task<List<EmployeeDTO>> getAllEmp();
    }
}
