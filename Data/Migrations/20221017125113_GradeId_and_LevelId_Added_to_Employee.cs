using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class GradeId_and_LevelId_Added_to_Employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_GradeId",
                table: "Employees",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LevelId",
                table: "Employees",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Grades_GradeId",
                table: "Employees",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Levels_LevelId",
                table: "Employees",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Grades_GradeId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Levels_LevelId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_GradeId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_LevelId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "Employees");
        }
    }
}
