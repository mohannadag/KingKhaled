using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class EmployeeShifts_add_EmployeeID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "EmployeeShifts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShifts_EmployeeId",
                table: "EmployeeShifts",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeShifts_Employees_EmployeeId",
                table: "EmployeeShifts",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeShifts_Employees_EmployeeId",
                table: "EmployeeShifts");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeShifts_EmployeeId",
                table: "EmployeeShifts");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "EmployeeShifts");
        }
    }
}
