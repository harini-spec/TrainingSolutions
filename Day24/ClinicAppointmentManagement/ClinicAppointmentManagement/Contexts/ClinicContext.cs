using ClinicAppointmentManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ClinicAppointmentManagement.Contexts
{
    public class ClinicContext : DbContext
    {
        public ClinicContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 101, Name = "Ram", DateOfBirth = new DateTime(2000, 2, 12), Gender = "Male", Specialization = "Neuro surgeon", Qualification = "MBBS", Experience = 4 },
                new Doctor() { Id = 102, Name = "Sam", DateOfBirth = new DateTime(1999, 2, 12), Gender = "Female", Specialization = "General surgeon", Qualification = "MBBS", Experience = 5 }
                );

            modelBuilder.Entity<Patient>().HasData(
                new Patient() { Id = 101, Name = "Sharma", DateOfBirth = new DateTime(2000, 2, 12), Gender = "Male", History = "Had an appendicitis surgery"},
                new Patient() { Id = 102, Name = "Vanathi", DateOfBirth = new DateTime(2000, 2, 12), Gender = "Female", History = "Is on withdrawal medication" }
                );

        }
    }
}
