using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebEmployeeSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmployeeModelV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "HealthContribution",
                table: "Employees",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PensionContribution",
                table: "Employees",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Tax",
                table: "Employees",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalTaxesAndContributions",
                table: "Employees",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UnemploymentContribution",
                table: "Employees",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                columns: new[] { "Email", "HealthContribution", "PensionContribution", "Tax", "TotalTaxesAndContributions", "UnemploymentContribution" },
                values: new object[] { "john@email.com", 0m, 0m, 0m, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                columns: new[] { "Email", "HealthContribution", "PensionContribution", "Tax", "TotalTaxesAndContributions", "UnemploymentContribution" },
                values: new object[] { "sarah@email.com", 0m, 0m, 0m, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                columns: new[] { "Email", "HealthContribution", "PensionContribution", "Tax", "TotalTaxesAndContributions", "UnemploymentContribution" },
                values: new object[] { "mark@email.com", 0m, 0m, 0m, 0m, 0m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "HealthContribution",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PensionContribution",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TotalTaxesAndContributions",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UnemploymentContribution",
                table: "Employees");
        }
    }
}
