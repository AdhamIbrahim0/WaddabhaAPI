using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Waddabha.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9c180e52-3c90-4bab-97fd-bd1bad545398", null, "Buyer", "BUYER" },
                    { "af3f9b9c-3c22-4d94-9049-faea7f0bd873", null, "Seller", "SELLER" },
                    { "d9be4831-a95f-4457-a1e5-12b5c26a3cd9", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c180e52-3c90-4bab-97fd-bd1bad545398");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af3f9b9c-3c22-4d94-9049-faea7f0bd873");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9be4831-a95f-4457-a1e5-12b5c26a3cd9");
        }
    }
}
