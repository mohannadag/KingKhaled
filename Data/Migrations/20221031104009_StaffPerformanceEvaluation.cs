using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class StaffPerformanceEvaluation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StaffPerformanceEvaluation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId1 = table.Column<int>(type: "int", nullable: true),
                    JobId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobId1 = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_StaffPerformanceEvaluation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffPerformanceEvaluation_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StaffPerformanceEvaluation_Jobs_JobId1",
                        column: x => x.JobId1,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkShifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartShift = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndShift = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    StaffPerformanceEvaluationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluations_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluations_StaffPerformanceEvaluation_StaffPerformanceEvaluationId",
                        column: x => x.StaffPerformanceEvaluationId,
                        principalTable: "StaffPerformanceEvaluation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeShifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkShiftsId = table.Column<int>(type: "int", nullable: false),
                    DayNumber = table.Column<int>(type: "int", nullable: false),
                    Presenceabsence = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    MonthDuration = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeShifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeShifts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeShifts_WorkShifts_WorkShiftsId",
                        column: x => x.WorkShiftsId,
                        principalTable: "WorkShifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShifts_EmployeeId",
                table: "EmployeeShifts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShifts_WorkShiftsId",
                table: "EmployeeShifts",
                column: "WorkShiftsId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_DepartmentId",
                table: "Evaluations",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_StaffPerformanceEvaluationId",
                table: "Evaluations",
                column: "StaffPerformanceEvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffPerformanceEvaluation_EmployeeId1",
                table: "StaffPerformanceEvaluation",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_StaffPerformanceEvaluation_JobId1",
                table: "StaffPerformanceEvaluation",
                column: "JobId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeShifts");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "WorkShifts");

            migrationBuilder.DropTable(
                name: "StaffPerformanceEvaluation");
        }
    }
}
