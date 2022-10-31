using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class ContractTransaction_Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContractTypeId",
                table: "ContractTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ContractTransactions_ContractTypeId",
                table: "ContractTransactions",
                column: "ContractTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractTransactions_ContractTypes_ContractTypeId",
                table: "ContractTransactions",
                column: "ContractTypeId",
                principalTable: "ContractTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractTransactions_ContractTypes_ContractTypeId",
                table: "ContractTransactions");

            migrationBuilder.DropIndex(
                name: "IX_ContractTransactions_ContractTypeId",
                table: "ContractTransactions");

            migrationBuilder.DropColumn(
                name: "ContractTypeId",
                table: "ContractTransactions");
        }
    }
}
