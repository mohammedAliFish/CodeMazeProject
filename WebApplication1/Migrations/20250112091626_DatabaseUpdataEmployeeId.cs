using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeMazeProject1.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseUpdataEmployeeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Employee Id",
                table: "Employees",
                newName: "Employee Guid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Employee Guid",
                table: "Employees",
                newName: "Employee Id");
        }
    }
}
