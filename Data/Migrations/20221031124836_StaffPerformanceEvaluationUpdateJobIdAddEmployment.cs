using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class StaffPerformanceEvaluationUpdateJobIdAddEmployment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffPerformanceEvaluation_Jobs_JobId1",
                table: "StaffPerformanceEvaluation");

            migrationBuilder.DropIndex(
                name: "IX_StaffPerformanceEvaluation_JobId1",
                table: "StaffPerformanceEvaluation");

            migrationBuilder.DropColumn(
                name: "JobId1",
                table: "StaffPerformanceEvaluation");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "StaffPerformanceEvaluation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffPerformanceEvaluation_JobId",
                table: "StaffPerformanceEvaluation",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffPerformanceEvaluation_Jobs_JobId",
                table: "StaffPerformanceEvaluation",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffPerformanceEvaluation_Jobs_JobId",
                table: "StaffPerformanceEvaluation");

            migrationBuilder.DropIndex(
                name: "IX_StaffPerformanceEvaluation_JobId",
                table: "StaffPerformanceEvaluation");

            migrationBuilder.AlterColumn<string>(
                name: "JobId",
                table: "StaffPerformanceEvaluation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "JobId1",
                table: "StaffPerformanceEvaluation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffPerformanceEvaluation_JobId1",
                table: "StaffPerformanceEvaluation",
                column: "JobId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffPerformanceEvaluation_Jobs_JobId1",
                table: "StaffPerformanceEvaluation",
                column: "JobId1",
                principalTable: "Jobs",
                principalColumn: "Id");
        }
    }
}
