using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DoctorAppointmentModelLibrary.Model
{
    public partial class DoctorAppointmentContext : DbContext
    {
        public DoctorAppointmentContext()
        {
        }

        public DoctorAppointmentContext(DbContextOptions<DoctorAppointmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DHLBBX3\\DEMOINSTANCE;Integrated Security=true;Initial Catalog=DoctorAppointment");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.AppointmentDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.DoctorNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.Doctor)
                    .HasConstraintName("fk_DoctorID");

                entity.HasOne(d => d.PatientNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.Patient)
                    .HasConstraintName("fk_PatientID");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Qualification)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Specialization)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
