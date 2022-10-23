using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class UpdateJobVacancy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "JobVacancies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JobVacancies_JobId",
                table: "JobVacancies",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobVacancies_Jobs_JobId",
                table: "JobVacancies",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobVacancies_Jobs_JobId",
                table: "JobVacancies");

            migrationBuilder.DropIndex(
                name: "IX_JobVacancies_JobId",
                table: "JobVacancies");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "JobVacancies");
        }
    }
}
