using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class JobVisa_Added_to_Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobVisaId",
                table: "Identities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Identities_JobVisaId",
                table: "Identities",
                column: "JobVisaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Identities_JobVisas_JobVisaId",
                table: "Identities",
                column: "JobVisaId",
                principalTable: "JobVisas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Identities_JobVisas_JobVisaId",
                table: "Identities");

            migrationBuilder.DropIndex(
                name: "IX_Identities_JobVisaId",
                table: "Identities");

            migrationBuilder.DropColumn(
                name: "JobVisaId",
                table: "Identities");
        }
    }
}
