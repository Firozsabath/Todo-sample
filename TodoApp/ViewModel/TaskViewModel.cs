using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.DTO;

namespace TodoApp.ViewModel
{
    public class TaskViewModel
    {
        public int TaskID { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int EmployeeID { get; set; }

        public EmployeeDTO Employee { get; set; }
    }
}
