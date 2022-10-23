using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class ManyToMany_JobGrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobGrade",
                table: "JobGrade");

            migrationBuilder.DropIndex(
                name: "IX_JobGrade_JobId",
                table: "JobGrade");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "JobGrade",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobGrade",
                table: "JobGrade",
                columns: new[] { "JobId", "GradeId" });

            migrationBuilder.CreateIndex(
                name: "IX_JobGrade_GradeId",
                table: "JobGrade",
                column: "GradeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobGrade",
                table: "JobGrade");

            migrationBuilder.DropIndex(
                name: "IX_JobGrade_GradeId",
                table: "JobGrade");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "JobGrade");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobGrade",
                table: "JobGrade",
                columns: new[] { "GradeId", "JobId" });

            migrationBuilder.CreateIndex(
                name: "IX_JobGrade_JobId",
                table: "JobGrade",
                column: "JobId");
        }
    }
}
