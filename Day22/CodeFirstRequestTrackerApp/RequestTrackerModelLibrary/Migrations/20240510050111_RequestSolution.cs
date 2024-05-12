using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestTrackerModelLibrary.Migrations
{
    public partial class RequestSolution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestSolution",
                columns: table => new
                {
                    RequestSolutionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Solution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SolutionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isSolved = table.Column<bool>(type: "bit", nullable: false),
                    RequestRaiserComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestNumber = table.Column<int>(type: "int", nullable: false),
                    SolutionGivenBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestSolution", x => x.RequestSolutionId);
                    table.ForeignKey(
                        name: "FK_RequestSolution_Employees_SolutionGivenBy",
                        column: x => x.SolutionGivenBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestSolution_Requests_RequestNumber",
                        column: x => x.RequestNumber,
                        principalTable: "Requests",
                        principalColumn: "RequestNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestSolution_RequestNumber",
                table: "RequestSolution",
                column: "RequestNumber");

            migrationBuilder.CreateIndex(
                name: "IX_RequestSolution_SolutionGivenBy",
                table: "RequestSolution",
                column: "SolutionGivenBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestSolution");
        }
    }
}
