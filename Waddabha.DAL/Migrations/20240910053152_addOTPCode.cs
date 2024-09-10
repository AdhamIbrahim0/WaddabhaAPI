using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waddabha.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addOTPCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OTPCode",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OTPCode",
                table: "AspNetUsers");
        }
    }
}
