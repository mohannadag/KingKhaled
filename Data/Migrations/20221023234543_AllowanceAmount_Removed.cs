using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AllowanceAmount_Removed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowanceAmount",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "AllowancePercentage",
                table: "Jobs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AllowanceAmount",
                table: "Jobs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AllowancePercentage",
                table: "Jobs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
