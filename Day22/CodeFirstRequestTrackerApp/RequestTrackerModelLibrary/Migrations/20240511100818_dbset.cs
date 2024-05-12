using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestTrackerModelLibrary.Migrations
{
    public partial class dbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestSolution_Employees_SolutionGivenBy",
                table: "RequestSolution");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestSolution_Requests_RequestNumber",
                table: "RequestSolution");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionFeedback_Employees_FeedbackGivenBy",
                table: "SolutionFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionFeedback_RequestSolution_RequestSolutionId",
                table: "SolutionFeedback");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolutionFeedback",
                table: "SolutionFeedback");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestSolution",
                table: "RequestSolution");

            migrationBuilder.RenameTable(
                name: "SolutionFeedback",
                newName: "SolutionFeedbacks");

            migrationBuilder.RenameTable(
                name: "RequestSolution",
                newName: "Solutions");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionFeedback_RequestSolutionId",
                table: "SolutionFeedbacks",
                newName: "IX_SolutionFeedbacks_RequestSolutionId");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionFeedback_FeedbackGivenBy",
                table: "SolutionFeedbacks",
                newName: "IX_SolutionFeedbacks_FeedbackGivenBy");

            migrationBuilder.RenameIndex(
                name: "IX_RequestSolution_SolutionGivenBy",
                table: "Solutions",
                newName: "IX_Solutions_SolutionGivenBy");

            migrationBuilder.RenameIndex(
                name: "IX_RequestSolution_RequestNumber",
                table: "Solutions",
                newName: "IX_Solutions_RequestNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolutionFeedbacks",
                table: "SolutionFeedbacks",
                column: "FeedbackId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Solutions",
                table: "Solutions",
                column: "RequestSolutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionFeedbacks_Employees_FeedbackGivenBy",
                table: "SolutionFeedbacks",
                column: "FeedbackGivenBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionFeedbacks_Solutions_RequestSolutionId",
                table: "SolutionFeedbacks",
                column: "RequestSolutionId",
                principalTable: "Solutions",
                principalColumn: "RequestSolutionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solutions_Employees_SolutionGivenBy",
                table: "Solutions",
                column: "SolutionGivenBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solutions_Requests_RequestNumber",
                table: "Solutions",
                column: "RequestNumber",
                principalTable: "Requests",
                principalColumn: "RequestNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolutionFeedbacks_Employees_FeedbackGivenBy",
                table: "SolutionFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionFeedbacks_Solutions_RequestSolutionId",
                table: "SolutionFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Solutions_Employees_SolutionGivenBy",
                table: "Solutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Solutions_Requests_RequestNumber",
                table: "Solutions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Solutions",
                table: "Solutions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolutionFeedbacks",
                table: "SolutionFeedbacks");

            migrationBuilder.RenameTable(
                name: "Solutions",
                newName: "RequestSolution");

            migrationBuilder.RenameTable(
                name: "SolutionFeedbacks",
                newName: "SolutionFeedback");

            migrationBuilder.RenameIndex(
                name: "IX_Solutions_SolutionGivenBy",
                table: "RequestSolution",
                newName: "IX_RequestSolution_SolutionGivenBy");

            migrationBuilder.RenameIndex(
                name: "IX_Solutions_RequestNumber",
                table: "RequestSolution",
                newName: "IX_RequestSolution_RequestNumber");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionFeedbacks_RequestSolutionId",
                table: "SolutionFeedback",
                newName: "IX_SolutionFeedback_RequestSolutionId");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionFeedbacks_FeedbackGivenBy",
                table: "SolutionFeedback",
                newName: "IX_SolutionFeedback_FeedbackGivenBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestSolution",
                table: "RequestSolution",
                column: "RequestSolutionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolutionFeedback",
                table: "SolutionFeedback",
                column: "FeedbackId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSolution_Employees_SolutionGivenBy",
                table: "RequestSolution",
                column: "SolutionGivenBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSolution_Requests_RequestNumber",
                table: "RequestSolution",
                column: "RequestNumber",
                principalTable: "Requests",
                principalColumn: "RequestNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionFeedback_Employees_FeedbackGivenBy",
                table: "SolutionFeedback",
                column: "FeedbackGivenBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionFeedback_RequestSolution_RequestSolutionId",
                table: "SolutionFeedback",
                column: "RequestSolutionId",
                principalTable: "RequestSolution",
                principalColumn: "RequestSolutionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
