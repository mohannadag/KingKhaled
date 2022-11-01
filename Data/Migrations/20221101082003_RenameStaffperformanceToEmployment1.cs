using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class RenameStaffperformanceToEmployment1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePerfomanc_StaffPerformanceEvaluation_StaffPerformanceEvaluationID",
                table: "EmployeePerfomanc");

            migrationBuilder.DropTable(
                name: "StaffPerformanceEvaluation");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePerfomanc_StaffPerformanceEvaluationID",
                table: "EmployeePerfomanc");

            migrationBuilder.AddColumn<int>(
                name: "EmploymentPerformanceEvaluationId",
                table: "EmployeePerfomanc",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmploymentPerformanceEvaluation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    EvaluationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDateEvaluation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateEvaluation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EvaluationKind = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrongPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoserPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recommendation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectionsAndRecommendations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enterby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPoint = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentPerformanceEvaluation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmploymentPerformanceEvaluation_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePerfomanc_EmploymentPerformanceEvaluationId",
                table: "EmployeePerfomanc",
                column: "EmploymentPerformanceEvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentPerformanceEvaluation_JobId",
                table: "EmploymentPerformanceEvaluation",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePerfomanc_EmploymentPerformanceEvaluation_EmploymentPerformanceEvaluationId",
                table: "EmployeePerfomanc",
                column: "EmploymentPerformanceEvaluationId",
                principalTable: "EmploymentPerformanceEvaluation",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePerfomanc_EmploymentPerformanceEvaluation_EmploymentPerformanceEvaluationId",
                table: "EmployeePerfomanc");

            migrationBuilder.DropTable(
                name: "EmploymentPerformanceEvaluation");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePerfomanc_EmploymentPerformanceEvaluationId",
                table: "EmployeePerfomanc");

            migrationBuilder.DropColumn(
                name: "EmploymentPerformanceEvaluationId",
                table: "EmployeePerfomanc");

            migrationBuilder.CreateTable(
                name: "StaffPerformanceEvaluation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId1 = table.Column<int>(type: "int", nullable: true),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    DirectionsAndRecommendations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDateEvaluation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enterby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvaluationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EvaluationKind = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoserPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recommendation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDateEvaluation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StrongPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPoint = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffPerformanceEvaluation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffPerformanceEvaluation_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StaffPerformanceEvaluation_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePerfomanc_StaffPerformanceEvaluationID",
                table: "EmployeePerfomanc",
                column: "StaffPerformanceEvaluationID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffPerformanceEvaluation_EmployeeId1",
                table: "StaffPerformanceEvaluation",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_StaffPerformanceEvaluation_JobId",
                table: "StaffPerformanceEvaluation",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePerfomanc_StaffPerformanceEvaluation_StaffPerformanceEvaluationID",
                table: "EmployeePerfomanc",
                column: "StaffPerformanceEvaluationID",
                principalTable: "StaffPerformanceEvaluation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
