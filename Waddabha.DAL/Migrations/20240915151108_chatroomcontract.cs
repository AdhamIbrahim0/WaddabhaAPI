using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waddabha.DAL.Migrations
{
    /// <inheritdoc />
    public partial class chatroomcontract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contracts_ChatRoomId",
                table: "Contracts");

            migrationBuilder.AlterColumn<string>(
                name: "ChatRoomId",
                table: "Contracts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ChatRoomId",
                table: "Contracts",
                column: "ChatRoomId",
                unique: true,
                filter: "[ChatRoomId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contracts_ChatRoomId",
                table: "Contracts");

            migrationBuilder.AlterColumn<string>(
                name: "ChatRoomId",
                table: "Contracts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ChatRoomId",
                table: "Contracts",
                column: "ChatRoomId",
                unique: true);
        }
    }
}
