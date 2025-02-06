using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodeMazeProject1.Migrations
{
    /// <inheritdoc />
    public partial class addRolsToDbs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70396b6d-4b44-413c-a08d-65c34f8687c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dff3f481-c44f-4a5c-a880-d166458f5783");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f03d8e4-432c-4e72-a1a6-ff1c678b9b72", null, "Manager", "MANAGER" },
                    { "2a5b0f91-67a7-44a1-b94f-89d2c12e3c65", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f03d8e4-432c-4e72-a1a6-ff1c678b9b72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a5b0f91-67a7-44a1-b94f-89d2c12e3c65");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "70396b6d-4b44-413c-a08d-65c34f8687c2", null, "Manager", "MANAGER" },
                    { "dff3f481-c44f-4a5c-a880-d166458f5783", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
