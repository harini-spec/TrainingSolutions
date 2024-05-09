using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationDemo
{
    internal class MigrationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DHLBBX3\\DEMOINSTANCE;Integrated Security=true;Initial Catalog=MigrationDemo");
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<TemporaryEmployee> TemporaryEmployees { get; set;}
        public DbSet<PermanentEmployee> PermanentEmployees { get; set;}
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Request> Requests { get; set; }    
    }
}
