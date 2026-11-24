using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaaPinden.Migrations
{
    /// <inheritdoc />
    public partial class tet3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "_posts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "_posts",
                columns: new[] { "PostID", "ApplicationUserID", "Author", "Content", "CreatedAt", "Image", "Title", "Video" },
                values: new object[] { 1, null, "Admin", "Dette er den første post på PaaPinden. Vi håber, du vil nyde at dele dine strikkeoplevelser her!", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Velkommen til PaaPinden!", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "_posts",
                keyColumn: "PostID",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "_posts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
