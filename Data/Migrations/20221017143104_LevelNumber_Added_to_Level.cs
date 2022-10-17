using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class LevelNumber_Added_to_Level : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LevelNumber",
                table: "Levels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Levels_LevelNumber",
                table: "Levels",
                column: "LevelNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Levels_LevelNumber",
                table: "Levels");

            migrationBuilder.DropColumn(
                name: "LevelNumber",
                table: "Levels");
        }
    }
}
