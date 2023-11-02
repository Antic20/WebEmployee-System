using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebEmployeeSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedEmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "FirstName", "LastName", "NetSalary", "Position" },
                values: new object[,]
                {
                    { 1, "103rd Ave", "John", "Tenehel", 10000m, "GM" },
                    { 2, "101rd Ave", "Sarah", "Picket", 20000m, "CEO" },
                    { 3, "104rd Ave", "Mark", "Ronson", 30000m, "Director" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);
        }
    }
}
