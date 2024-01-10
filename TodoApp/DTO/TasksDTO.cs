using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.DTO
{
    public class TasksDTO
    {
        public int TaskID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int EmployeeID { get; set; }

        public string Employee { get; set; }
    }
}
