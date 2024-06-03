﻿// <auto-generated />
using System;
using EmployeeRequestTrackerAppWithAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeRequestTrackerAppWithAPI.Migrations
{
    [DbContext(typeof(RequestTrackerContext))]
    [Migration("20240517132902_RoleInsertionChanged")]
    partial class RoleInsertionChanged
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmployeeRequestTrackerAppWithAPI.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            DateOfBirth = new DateTime(2000, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "",
                            Name = "Ramu",
                            Phone = "9876543321",
                            Role = "User"
                        },
                        new
                        {
                            Id = 102,
                            DateOfBirth = new DateTime(2002, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "",
                            Name = "Somu",
                            Phone = "9988776655",
                            Role = "Admin"
                        });
                });

            modelBuilder.Entity("EmployeeRequestTrackerAppWithAPI.Models.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ClosedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ClosedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("RaisedById")
                        .HasColumnType("int");

                    b.Property<string>("RequestMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClosedById");

                    b.HasIndex("RaisedById");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("EmployeeRequestTrackerAppWithAPI.Models.UserModel", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordHashKey")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EmployeeRequestTrackerAppWithAPI.Models.Request", b =>
                {
                    b.HasOne("EmployeeRequestTrackerAppWithAPI.Models.Employee", "ClosedByEmployee")
                        .WithMany("ClosedRequests")
                        .HasForeignKey("ClosedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EmployeeRequestTrackerAppWithAPI.Models.Employee", "RaisedByEmployee")
                        .WithMany("RaisedRequests")
                        .HasForeignKey("RaisedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ClosedByEmployee");

                    b.Navigation("RaisedByEmployee");
                });

            modelBuilder.Entity("EmployeeRequestTrackerAppWithAPI.Models.UserModel", b =>
                {
                    b.HasOne("EmployeeRequestTrackerAppWithAPI.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EmployeeRequestTrackerAppWithAPI.Models.Employee", b =>
                {
                    b.Navigation("ClosedRequests");

                    b.Navigation("RaisedRequests");
                });
#pragma warning restore 612, 618
        }
    }
}