using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class applicationjob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmploymentApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmploymentNumber = table.Column<int>(type: "int", nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalityID = table.Column<int>(type: "int", nullable: false),
                    ReligionID = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    TelPhoneNumber = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Recommended = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualificationID = table.Column<int>(type: "int", nullable: false),
                    yearsExperience = table.Column<int>(type: "int", nullable: false),
                    ExperienceNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResidenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResidenceStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResidenceEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResidencePlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResidenceJobID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exam = table.Column<bool>(type: "bit", nullable: false),
                    HospitalExam = table.Column<bool>(type: "bit", nullable: false),
                    MilitaryExam = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentApplications", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmploymentApplications");
        }
    }
}
