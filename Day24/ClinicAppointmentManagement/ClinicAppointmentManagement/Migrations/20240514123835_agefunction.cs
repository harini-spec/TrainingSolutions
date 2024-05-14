using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicAppointmentManagement.Migrations
{
    public partial class agefunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 101,
                column: "Age",
                value: 2023);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 102,
                column: "Age",
                value: 2023);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 101,
                column: "Age",
                value: 2023);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 102,
                column: "Age",
                value: 2023);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 101,
                column: "Age",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 102,
                column: "Age",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 101,
                column: "Age",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 102,
                column: "Age",
                value: 0);
        }
    }
}
