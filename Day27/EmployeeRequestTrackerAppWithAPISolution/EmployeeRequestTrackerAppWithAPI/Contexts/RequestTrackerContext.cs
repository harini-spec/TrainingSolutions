using EmployeeRequestTrackerAppWithAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EmployeeRequestTrackerAppWithAPI.Contexts
{
    public class RequestTrackerContext : DbContext
    {
        public RequestTrackerContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<Request> Requests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 101, Name = "Ramu", DateOfBirth = new DateTime(2000, 2, 12), Phone = "9876543321", Image = "", Role = "User" },
                new Employee() { Id = 102, Name = "Somu", DateOfBirth = new DateTime(2002, 3, 24), Phone = "9988776655", Image = "", Role = "Admin" }
                );

            modelBuilder.Entity<Request>()
                .HasOne(r => r.RaisedByEmployee)
                .WithMany(e => e.RaisedRequests)
                .HasForeignKey(r => r.RaisedById)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Request>()
                .HasOne(r => r.ClosedByEmployee)
                .WithMany(e => e.ClosedRequests)
                .HasForeignKey(r => r.ClosedById)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
