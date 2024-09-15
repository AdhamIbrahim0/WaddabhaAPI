using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waddabha.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRejectionMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RejectionMessage",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RejectionMessage",
                table: "Services");
        }
    }
}
