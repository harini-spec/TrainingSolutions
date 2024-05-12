using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary
{
    public class RequestTrackerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DHLBBX3\DEMOINSTANCE;Integrated Security=true;Initial Catalog=dbCFRequestTracker;");
        }
        public DbSet<Employee> Employees { get; set; } // table will be created if specified as DbSet
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestSolution> Solutions { get; set; }
        public DbSet<SolutionFeedback> SolutionFeedbacks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 101, Name = "Ramu", Password = "ramu123", Role = "Admin" },
                new Employee { Id = 102, Name = "Somu", Password = "somu123", Role = "Admin" },
                new Employee { Id = 103, Name = "Bimu", Password = "bimu123", Role = "User" }
                );

            modelBuilder.Entity<Request>().HasKey(r => r.RequestNumber);
            modelBuilder.Entity<SolutionFeedback>().HasKey(f => f.FeedbackId);

            modelBuilder.Entity<Request>()
               .HasOne(r => r.RaisedByEmployee)
               .WithMany(e => e.RequestsRaised)
               .HasForeignKey(r => r.RequestRaisedBy)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();

            modelBuilder.Entity<Request>()
               .HasOne(r => r.RequestClosedByEmployee)
               .WithMany(e => e.RequestsClosed)
               .HasForeignKey(r => r.RequestClosedBy)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RequestSolution>()
                .HasOne(rs => rs.SolutionGivenByEmployee)
                .WithMany(e => e.SolutionsGiven)
                .HasForeignKey(rs => rs.SolutionGivenBy)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<RequestSolution>()
                .HasOne(rs => rs.RequestRaised)
                .WithMany(r => r.SolutionsGiven)
                .HasForeignKey(rs => rs.RequestNumber)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<SolutionFeedback>()
                .HasOne(f => f.FeedbackGivenByEmployee)
                .WithMany(e => e.FeedbacksGiven)
                .HasForeignKey(f => f.FeedbackGivenBy)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<SolutionFeedback>()
                .HasOne(f => f.RequestSolutionGiven)
                .WithMany(r => r.FeedbacksGiven)
                .HasForeignKey(f => f.RequestSolutionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}