using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class updateEmploymentApplicatoin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResidenceJobID",
                table: "EmploymentApplications");

            migrationBuilder.RenameColumn(
                name: "yearsExperience",
                table: "EmploymentApplications",
                newName: "YearsExperience");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "EmploymentApplications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobVisaID",
                table: "EmploymentApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentApplications_JobId",
                table: "EmploymentApplications",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentApplications_JobVisaID",
                table: "EmploymentApplications",
                column: "JobVisaID");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentApplications_QualificationID",
                table: "EmploymentApplications",
                column: "QualificationID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmploymentApplications_Jobs_JobId",
                table: "EmploymentApplications",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmploymentApplications_JobVisas_JobVisaID",
                table: "EmploymentApplications",
                column: "JobVisaID",
                principalTable: "JobVisas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmploymentApplications_Qualifications_QualificationID",
                table: "EmploymentApplications",
                column: "QualificationID",
                principalTable: "Qualifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmploymentApplications_Jobs_JobId",
                table: "EmploymentApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_EmploymentApplications_JobVisas_JobVisaID",
                table: "EmploymentApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_EmploymentApplications_Qualifications_QualificationID",
                table: "EmploymentApplications");

            migrationBuilder.DropIndex(
                name: "IX_EmploymentApplications_JobId",
                table: "EmploymentApplications");

            migrationBuilder.DropIndex(
                name: "IX_EmploymentApplications_JobVisaID",
                table: "EmploymentApplications");

            migrationBuilder.DropIndex(
                name: "IX_EmploymentApplications_QualificationID",
                table: "EmploymentApplications");

            migrationBuilder.DropColumn(
                name: "JobVisaID",
                table: "EmploymentApplications");

            migrationBuilder.RenameColumn(
                name: "YearsExperience",
                table: "EmploymentApplications",
                newName: "yearsExperience");

            migrationBuilder.AlterColumn<string>(
                name: "JobId",
                table: "EmploymentApplications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ResidenceJobID",
                table: "EmploymentApplications",
                type: "nvarchar(max)",
                nullable: true);
            migrationBuilder.DropColumn(
         name: "ReligionID",
         table: "EmploymentApplications");

            migrationBuilder.AddColumn<string>(
                name: "EmploymentApplications",
                table: "Religion",
                nullable: true); 
        }
    }
}
