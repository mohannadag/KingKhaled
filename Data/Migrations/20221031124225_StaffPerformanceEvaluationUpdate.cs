using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class StaffPerformanceEvaluationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffPerformanceEvaluation_Employees_EmployeeId1",
                table: "StaffPerformanceEvaluation");

            migrationBuilder.DropIndex(
                name: "IX_StaffPerformanceEvaluation_EmployeeId1",
                table: "StaffPerformanceEvaluation");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "StaffPerformanceEvaluation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId1",
                table: "StaffPerformanceEvaluation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffPerformanceEvaluation_EmployeeId1",
                table: "StaffPerformanceEvaluation",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffPerformanceEvaluation_Employees_EmployeeId1",
                table: "StaffPerformanceEvaluation",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
