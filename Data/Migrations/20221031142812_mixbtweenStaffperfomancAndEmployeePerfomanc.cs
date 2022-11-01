using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class mixbtweenStaffperfomancAndEmployeePerfomanc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_StaffPerformanceEvaluation_StaffPerformanceEvaluationId",
                table: "Evaluations");

            migrationBuilder.DropIndex(
                name: "IX_Evaluations_StaffPerformanceEvaluationId",
                table: "Evaluations");

            migrationBuilder.DropColumn(
                name: "StaffPerformanceEvaluationId",
                table: "Evaluations");

            migrationBuilder.CreateTable(
                name: "EmployeePerfomanc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffPerformanceEvaluationID = table.Column<int>(type: "int", nullable: false),
                    EvaluationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePerfomanc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePerfomanc_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePerfomanc_StaffPerformanceEvaluation_StaffPerformanceEvaluationID",
                        column: x => x.StaffPerformanceEvaluationID,
                        principalTable: "StaffPerformanceEvaluation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePerfomanc_EvaluationId",
                table: "EmployeePerfomanc",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePerfomanc_StaffPerformanceEvaluationID",
                table: "EmployeePerfomanc",
                column: "StaffPerformanceEvaluationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeePerfomanc");

            migrationBuilder.AddColumn<int>(
                name: "StaffPerformanceEvaluationId",
                table: "Evaluations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_StaffPerformanceEvaluationId",
                table: "Evaluations",
                column: "StaffPerformanceEvaluationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_StaffPerformanceEvaluation_StaffPerformanceEvaluationId",
                table: "Evaluations",
                column: "StaffPerformanceEvaluationId",
                principalTable: "StaffPerformanceEvaluation",
                principalColumn: "Id");
        }
    }
}
