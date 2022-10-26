using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class updateEmploymentApplicatoin1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReligionID",
                table: "EmploymentApplications");

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                table: "EmploymentApplications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentApplications_NationalityID",
                table: "EmploymentApplications",
                column: "NationalityID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmploymentApplications_Nationalities_NationalityID",
                table: "EmploymentApplications",
                column: "NationalityID",
                principalTable: "Nationalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmploymentApplications_Nationalities_NationalityID",
                table: "EmploymentApplications");

            migrationBuilder.DropIndex(
                name: "IX_EmploymentApplications_NationalityID",
                table: "EmploymentApplications");

            migrationBuilder.DropColumn(
                name: "Religion",
                table: "EmploymentApplications");

            migrationBuilder.AddColumn<int>(
                name: "ReligionID",
                table: "EmploymentApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
