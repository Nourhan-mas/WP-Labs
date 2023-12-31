using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App1.Migrations
{
	/// <inheritdoc />
	public partial class fourth : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<int>(
				name: "EmployeeId",
				table: "SalaryInfos",
				type: "int",
				nullable: false,
				defaultValue: 0);
			migrationBuilder.InsertData(
				table: "SalaryInfos",
				columns: new[] { "EmployeeId", "Net", "Gross" },
				values: new object[,]
				{
					{ 1, 2500, 3000 },
					{ 2, 2500, 3000 },
					{ 3, 2500, 3000 },
					{ 4, 2500, 3000 },
					{ 5, 2500, 3000 },
					{ 6, 2500, 3000 },
					{ 7, 2500, 3000 },
					{ 8, 2500, 3000 },
				});
			migrationBuilder.CreateIndex(
				name: "IX_SalaryInfos_EmployeeId",
				table: "SalaryInfos",
				column: "EmployeeId",
				unique: true);

			migrationBuilder.AddForeignKey(
				name: "FK_SalaryInfos_Employees_EmployeeId",
				table: "SalaryInfos",
				column: "EmployeeId",
				principalTable: "Employees",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_SalaryInfos_Employees_EmployeeId",
				table: "SalaryInfos");

			migrationBuilder.DropIndex(
				name: "IX_SalaryInfos_EmployeeId",
				table: "SalaryInfos");

			migrationBuilder.DropColumn(
				name: "EmployeeId",
				table: "SalaryInfos");
		}
	}
}
