using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Added_JobVacancy_to_Employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobVacancyId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobVacancyId",
                table: "Employees",
                column: "JobVacancyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_JobVacancies_JobVacancyId",
                table: "Employees",
                column: "JobVacancyId",
                principalTable: "JobVacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_JobVacancies_JobVacancyId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_JobVacancyId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "JobVacancyId",
                table: "Employees");
        }
    }
}
