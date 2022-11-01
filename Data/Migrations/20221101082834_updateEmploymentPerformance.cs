using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class updateEmploymentPerformance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmploymentPerformanceEvaluation_Jobs_JobId",
                table: "EmploymentPerformanceEvaluation");

            migrationBuilder.DropIndex(
                name: "IX_EmploymentPerformanceEvaluation_JobId",
                table: "EmploymentPerformanceEvaluation");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "EmploymentPerformanceEvaluation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "EmploymentPerformanceEvaluation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentPerformanceEvaluation_JobId",
                table: "EmploymentPerformanceEvaluation",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmploymentPerformanceEvaluation_Jobs_JobId",
                table: "EmploymentPerformanceEvaluation",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
