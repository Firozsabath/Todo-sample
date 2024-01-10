using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    public class Tasks
    {
        [Key]
        public int TaskID { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int EmployeeID { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employees { get; set; }

    }
}
