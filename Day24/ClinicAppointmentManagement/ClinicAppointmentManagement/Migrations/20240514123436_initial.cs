using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicAppointmentManagement.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    AppointedDoctorId = table.Column<int>(type: "int", nullable: false),
                    AppointmentForPatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_AppointedDoctorId",
                        column: x => x.AppointedDoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_AppointmentForPatientId",
                        column: x => x.AppointmentForPatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Age", "DateOfBirth", "Experience", "Name", "Qualification", "Specialization" },
                values: new object[,]
                {
                    { 101, 2023, new DateTime(2000, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Ram", "MBBS", "Neuro surgeon" },
                    { 102, 2023, new DateTime(1999, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Sam", "MBBS", "General surgeon" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Age", "DateOfBirth", "Gender", "History", "Name" },
                values: new object[,]
                {
                    { 101, 2023, new DateTime(2000, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "Had an appendicitis surgery", "Sharma" },
                    { 102, 2023, new DateTime(2000, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "Is on withdrawal medication", "Vanathi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointedDoctorId",
                table: "Appointments",
                column: "AppointedDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentForPatientId",
                table: "Appointments",
                column: "AppointmentForPatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
