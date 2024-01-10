using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
    }
}
