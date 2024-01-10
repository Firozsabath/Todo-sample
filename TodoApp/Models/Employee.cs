using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Postion { get; set; }
        public string Department { get; set; }

        public ICollection<Tasks> Tasks { get; set; }
    }
}
