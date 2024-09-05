using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waddabha.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ServiceImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Images",
                table: "Services",
                newName: "ImagePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Services",
                newName: "Images");
        }
    }
}
