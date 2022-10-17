using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Qualification_Added_to_Employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QualificationId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_QualificationId",
                table: "Employees",
                column: "QualificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Qualifications_QualificationId",
                table: "Employees",
                column: "QualificationId",
                principalTable: "Qualifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Qualifications_QualificationId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_QualificationId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "QualificationId",
                table: "Employees");
        }
    }
}
