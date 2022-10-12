using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Job_Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobSubGroupId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxRank",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinRank",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "WorkNatureAllowance",
                table: "Jobs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobSubGroupId",
                table: "Jobs",
                column: "JobSubGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobSubGroups_JobSubGroupId",
                table: "Jobs",
                column: "JobSubGroupId",
                principalTable: "JobSubGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobSubGroups_JobSubGroupId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_JobSubGroupId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobSubGroupId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "MaxRank",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "MinRank",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "WorkNatureAllowance",
                table: "Jobs");
        }
    }
}
