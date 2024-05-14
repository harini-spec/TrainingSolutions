using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicAppointmentManagement.Migrations
{
    public partial class AgeFunctionCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Doctors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
