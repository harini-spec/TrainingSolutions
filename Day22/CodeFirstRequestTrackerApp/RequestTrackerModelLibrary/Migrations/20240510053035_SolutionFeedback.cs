using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestTrackerModelLibrary.Migrations
{
    public partial class SolutionFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SolutionFeedback",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    FeedbackDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestSolutionId = table.Column<int>(type: "int", nullable: false),
                    FeedbackGivenBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionFeedback", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_SolutionFeedback_Employees_FeedbackGivenBy",
                        column: x => x.FeedbackGivenBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SolutionFeedback_RequestSolution_RequestSolutionId",
                        column: x => x.RequestSolutionId,
                        principalTable: "RequestSolution",
                        principalColumn: "RequestSolutionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolutionFeedback_FeedbackGivenBy",
                table: "SolutionFeedback",
                column: "FeedbackGivenBy");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionFeedback_RequestSolutionId",
                table: "SolutionFeedback",
                column: "RequestSolutionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolutionFeedback");
        }
    }
}
