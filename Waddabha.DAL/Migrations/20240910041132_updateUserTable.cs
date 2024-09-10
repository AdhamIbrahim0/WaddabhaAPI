using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waddabha.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict); // Change cascade to restrict
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ImageId",
                table: "Categories",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ServiceId",
                table: "Image",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Image_ImageId",
                table: "AspNetUsers",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict); // Change cascade to restrict

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Image_ImageId",
                table: "Categories",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict); // Change cascade to restrict
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Image_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Image_ImageId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ImageId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
