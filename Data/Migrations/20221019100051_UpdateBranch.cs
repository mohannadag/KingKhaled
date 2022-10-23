using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class UpdateBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobVacancies_Departments_DepartmentId",
                table: "JobVacancies");

            migrationBuilder.DropColumn(
                name: "NumberOfVacant",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "JobVacancies",
                newName: "BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_JobVacancies_DepartmentId",
                table: "JobVacancies",
                newName: "IX_JobVacancies_BranchId");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfVacant",
                table: "Branches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_JobVacancies_Branches_BranchId",
                table: "JobVacancies",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobVacancies_Branches_BranchId",
                table: "JobVacancies");

            migrationBuilder.DropColumn(
                name: "NumberOfVacant",
                table: "Branches");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                table: "JobVacancies",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_JobVacancies_BranchId",
                table: "JobVacancies",
                newName: "IX_JobVacancies_DepartmentId");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfVacant",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_JobVacancies_Departments_DepartmentId",
                table: "JobVacancies",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
