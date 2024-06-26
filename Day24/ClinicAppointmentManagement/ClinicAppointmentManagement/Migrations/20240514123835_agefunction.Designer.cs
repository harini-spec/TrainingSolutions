﻿// <auto-generated />
using System;
using ClinicAppointmentManagement.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClinicAppointmentManagement.Migrations
{
    [DbContext(typeof(ClinicContext))]
    [Migration("20240514123835_agefunction")]
    partial class agefunction
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClinicAppointmentManagement.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AppointedDoctorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("AppointmentForPatientId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AppointedDoctorId");

                    b.HasIndex("AppointmentForPatientId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("ClinicAppointmentManagement.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Qualification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            Age = 0,
                            DateOfBirth = new DateTime(2000, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Experience = 4,
                            Name = "Ram",
                            Qualification = "MBBS",
                            Specialization = "Neuro surgeon"
                        },
                        new
                        {
                            Id = 102,
                            Age = 0,
                            DateOfBirth = new DateTime(1999, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Experience = 5,
                            Name = "Sam",
                            Qualification = "MBBS",
                            Specialization = "General surgeon"
                        });
                });

            modelBuilder.Entity("ClinicAppointmentManagement.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("History")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            Age = 0,
                            DateOfBirth = new DateTime(2000, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "Male",
                            History = "Had an appendicitis surgery",
                            Name = "Sharma"
                        },
                        new
                        {
                            Id = 102,
                            Age = 0,
                            DateOfBirth = new DateTime(2000, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "Female",
                            History = "Is on withdrawal medication",
                            Name = "Vanathi"
                        });
                });

            modelBuilder.Entity("ClinicAppointmentManagement.Models.Appointment", b =>
                {
                    b.HasOne("ClinicAppointmentManagement.Models.Doctor", "AppointedDoctor")
                        .WithMany("DoctorAppointments")
                        .HasForeignKey("AppointedDoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicAppointmentManagement.Models.Patient", "AppointmentForPatient")
                        .WithMany("PatientAppointments")
                        .HasForeignKey("AppointmentForPatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppointedDoctor");

                    b.Navigation("AppointmentForPatient");
                });

            modelBuilder.Entity("ClinicAppointmentManagement.Models.Doctor", b =>
                {
                    b.Navigation("DoctorAppointments");
                });

            modelBuilder.Entity("ClinicAppointmentManagement.Models.Patient", b =>
                {
                    b.Navigation("PatientAppointments");
                });
#pragma warning restore 612, 618
        }
    }
}
