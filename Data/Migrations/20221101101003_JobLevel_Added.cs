using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class JobLevel_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobLevelId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "JobLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLevels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobLevelId",
                table: "Jobs",
                column: "JobLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobLevels_JobLevelId",
                table: "Jobs",
                column: "JobLevelId",
                principalTable: "JobLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobLevels_JobLevelId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "JobLevels");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_JobLevelId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobLevelId",
                table: "Jobs");
        }
    }
}
