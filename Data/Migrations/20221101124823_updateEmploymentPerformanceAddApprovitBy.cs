using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class updateEmploymentPerformanceAddApprovitBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EvaluationKind",
                table: "EmploymentPerformanceEvaluation",
                newName: "Approvitby");

            migrationBuilder.AddColumn<int>(
                name: "EvaluationType",
                table: "EmploymentPerformanceEvaluation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvaluationType",
                table: "EmploymentPerformanceEvaluation");

            migrationBuilder.RenameColumn(
                name: "Approvitby",
                table: "EmploymentPerformanceEvaluation",
                newName: "EvaluationKind");
        }
    }
}
