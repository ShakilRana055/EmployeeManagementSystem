using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystem.Migrations
{
    public partial class salaryStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalaryStructure_Employee_EmployeeId1",
                table: "SalaryStructure");

            migrationBuilder.DropIndex(
                name: "IX_SalaryStructure_EmployeeId1",
                table: "SalaryStructure");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "SalaryStructure");

            migrationBuilder.DropColumn(
                name: "EmployeeIdPk",
                table: "SalaryStructure");

            migrationBuilder.AddColumn<int>(
                name: "SalaryStructureId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_SalaryStructureId",
                table: "Employee",
                column: "SalaryStructureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_SalaryStructure_SalaryStructureId",
                table: "Employee",
                column: "SalaryStructureId",
                principalTable: "SalaryStructure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_SalaryStructure_SalaryStructureId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_SalaryStructureId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "SalaryStructureId",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId1",
                table: "SalaryStructure",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeIdPk",
                table: "SalaryStructure",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalaryStructure_EmployeeId1",
                table: "SalaryStructure",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SalaryStructure_Employee_EmployeeId1",
                table: "SalaryStructure",
                column: "EmployeeId1",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
