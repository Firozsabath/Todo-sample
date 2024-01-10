using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Contracts;
using TodoApp.DTO;

namespace TodoApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITasksOps tasksOps;

        public TasksController(ITasksOps tasksOps)
        {
            this.tasksOps = tasksOps;
        }
        public async Task<IActionResult> Index()
        {           
            return View(await this.tasksOps.FindAll());
        }

        public async Task<IActionResult> AddTask()
        {
            var employees = await this.tasksOps.getAllEmp();
            ViewBag.employeeList = employees;
            return View();
        }

        //[HttpPost]
        public async Task<IActionResult> CreateTask(TasksDTO tasksDTO)
        {
            try
            {
                var isSccuess = await this.tasksOps.Create(tasksDTO);
                return Json(new { isValid = true, message = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { isValid = false, message = ex.Message });               
            }
        }

        public async Task<IActionResult> ReturnPartials(string Type)
        {
            string partialView = string.Empty;           
            if (Type == "MyTasks")
            {
                var tasks = await this.tasksOps.FindAll();
                partialView = "~/Views/Shared/_TasksList.cshtml";
                return PartialView(partialView, tasks);
            }
            return PartialView(partialView, "");
        }
    }
}
