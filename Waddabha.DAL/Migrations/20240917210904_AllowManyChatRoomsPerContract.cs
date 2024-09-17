using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waddabha.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AllowManyChatRoomsPerContract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contracts_ChatRoomId",
                table: "Contracts");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ChatRoomId",
                table: "Contracts",
                column: "ChatRoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contracts_ChatRoomId",
                table: "Contracts");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ChatRoomId",
                table: "Contracts",
                column: "ChatRoomId",
                unique: true,
                filter: "[ChatRoomId] IS NOT NULL");
        }
    }
}
