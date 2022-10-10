using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Nationality_Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Nationalities",
                newName: "EnglishName");

            migrationBuilder.AddColumn<string>(
                name: "ArabicName",
                table: "Nationalities",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArabicName",
                table: "Nationalities");

            migrationBuilder.RenameColumn(
                name: "EnglishName",
                table: "Nationalities",
                newName: "Name");
        }
    }
}
