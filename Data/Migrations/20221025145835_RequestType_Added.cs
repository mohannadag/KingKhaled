using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class RequestType_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntryCard_Employees_EmployeeId",
                table: "EntryCard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntryCard",
                table: "EntryCard");

            migrationBuilder.RenameTable(
                name: "EntryCard",
                newName: "EntryCards");

            migrationBuilder.RenameIndex(
                name: "IX_EntryCard_EmployeeId",
                table: "EntryCards",
                newName: "IX_EntryCards_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntryCards",
                table: "EntryCards",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RequestTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestTypes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EntryCards_Employees_EmployeeId",
                table: "EntryCards",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntryCards_Employees_EmployeeId",
                table: "EntryCards");

            migrationBuilder.DropTable(
                name: "RequestTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntryCards",
                table: "EntryCards");

            migrationBuilder.RenameTable(
                name: "EntryCards",
                newName: "EntryCard");

            migrationBuilder.RenameIndex(
                name: "IX_EntryCards_EmployeeId",
                table: "EntryCard",
                newName: "IX_EntryCard_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntryCard",
                table: "EntryCard",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EntryCard_Employees_EmployeeId",
                table: "EntryCard",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
