using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeiterfassung1.Model;

namespace Zeiterfassung1
{
    class ZeiterfassungContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Zeiterfassung1");
        }

        public DbSet<Project> Projects { get; set; } 
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeActivity> EmployeeActivity { get; set; }
    }
}
