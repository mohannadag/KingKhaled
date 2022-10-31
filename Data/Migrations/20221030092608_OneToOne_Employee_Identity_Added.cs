using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class OneToOne_Employee_Identity_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Identities_EmployeeId",
                table: "Identities");

            migrationBuilder.CreateIndex(
                name: "IX_Identities_EmployeeId",
                table: "Identities",
                column: "EmployeeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Identities_EmployeeId",
                table: "Identities");

            migrationBuilder.CreateIndex(
                name: "IX_Identities_EmployeeId",
                table: "Identities",
                column: "EmployeeId");
        }
    }
}
