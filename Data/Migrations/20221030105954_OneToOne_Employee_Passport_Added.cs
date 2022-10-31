using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class OneToOne_Employee_Passport_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Passports_EmployeeId",
                table: "Passports");

            migrationBuilder.CreateIndex(
                name: "IX_Passports_EmployeeId",
                table: "Passports",
                column: "EmployeeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Passports_EmployeeId",
                table: "Passports");

            migrationBuilder.CreateIndex(
                name: "IX_Passports_EmployeeId",
                table: "Passports",
                column: "EmployeeId");
        }
    }
}
