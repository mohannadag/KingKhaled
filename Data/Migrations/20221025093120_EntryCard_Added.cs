using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class EntryCard_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntryCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecurityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    SecurityIssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SecurityIssueDateHijri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SecurityExpireDateHijri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentExpireDateHijri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryCard_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntryCard_EmployeeId",
                table: "EntryCard",
                column: "EmployeeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntryCard");
        }
    }
}
