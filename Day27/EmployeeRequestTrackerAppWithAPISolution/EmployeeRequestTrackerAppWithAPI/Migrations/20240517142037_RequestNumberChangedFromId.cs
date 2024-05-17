using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRequestTrackerAppWithAPI.Migrations
{
    public partial class RequestNumberChangedFromId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Requests",
                newName: "RequestNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestNumber",
                table: "Requests",
                newName: "Id");
        }
    }
}
