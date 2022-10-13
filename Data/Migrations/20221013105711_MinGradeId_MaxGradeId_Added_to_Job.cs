using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class MinGradeId_MaxGradeId_Added_to_Job : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxGradeId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinGradeId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_MaxGradeId",
                table: "Jobs",
                column: "MaxGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_MinGradeId",
                table: "Jobs",
                column: "MinGradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Grades_MaxGradeId",
                table: "Jobs",
                column: "MaxGradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Grades_MinGradeId",
                table: "Jobs",
                column: "MinGradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Grades_MaxGradeId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Grades_MinGradeId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_MaxGradeId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_MinGradeId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "MaxGradeId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "MinGradeId",
                table: "Jobs");
        }
    }
}
