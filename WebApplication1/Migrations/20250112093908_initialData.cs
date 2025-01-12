using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodeMazeProject1.Migrations
{
    /// <inheritdoc />
    public partial class initialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Company Guid", "CompanyAddress", "CompanyName", "Country" },
                values: new object[,]
                {
                    { new Guid("c9d4c053-49b0-4a8c-8e0d-3b5f5f6f6f9b"), "583 Wall Dr. Gwynn Oak, MD 21207", "IT Solutions Ltd", "United States" },
                    { new Guid("d8e506f1-1d3f-4b3f-8f0a-2f3f6f6f6f9b"), "312 Forest Avenue, BF 923", "Admin Solutions Ltd", "United States" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Employee Guid", "CompanyGuid", "EmployeeAge", "EmployeeName", "EmployeePosition" },
                values: new object[,]
                {
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new Guid("d8e506f1-1d3f-4b3f-8f0a-2f3f6f6f6f9b"), 35, "Kane Miller", "Administrator" },
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("c9d4c053-49b0-4a8c-8e0d-3b5f5f6f6f9b"), 26, "Sam Raiden", "Software developer" },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), new Guid("c9d4c053-49b0-4a8c-8e0d-3b5f5f6f6f9b"), 30, "Jana McLeaf", "Software developer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Employee Guid",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Employee Guid",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Employee Guid",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Company Guid",
                keyValue: new Guid("c9d4c053-49b0-4a8c-8e0d-3b5f5f6f6f9b"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Company Guid",
                keyValue: new Guid("d8e506f1-1d3f-4b3f-8f0a-2f3f6f6f6f9b"));
        }
    }
}
