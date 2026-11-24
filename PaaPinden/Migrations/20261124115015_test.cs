using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaaPinden.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Post_PostID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Post_PostID",
                table: "Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_ApplicationUserID",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "_posts");

            migrationBuilder.RenameIndex(
                name: "IX_Post_ApplicationUserID",
                table: "_posts",
                newName: "IX__posts_ApplicationUserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__posts",
                table: "_posts",
                column: "PostID");

            migrationBuilder.AddForeignKey(
                name: "FK__posts_AspNetUsers_ApplicationUserID",
                table: "_posts",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment__posts_PostID",
                table: "Comment",
                column: "PostID",
                principalTable: "_posts",
                principalColumn: "PostID");

            migrationBuilder.AddForeignKey(
                name: "FK_Like__posts_PostID",
                table: "Like",
                column: "PostID",
                principalTable: "_posts",
                principalColumn: "PostID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__posts_AspNetUsers_ApplicationUserID",
                table: "_posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment__posts_PostID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Like__posts_PostID",
                table: "Like");

            migrationBuilder.DropPrimaryKey(
                name: "PK__posts",
                table: "_posts");

            migrationBuilder.RenameTable(
                name: "_posts",
                newName: "Post");

            migrationBuilder.RenameIndex(
                name: "IX__posts_ApplicationUserID",
                table: "Post",
                newName: "IX_Post_ApplicationUserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "PostID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_PostID",
                table: "Comment",
                column: "PostID",
                principalTable: "Post",
                principalColumn: "PostID");

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Post_PostID",
                table: "Like",
                column: "PostID",
                principalTable: "Post",
                principalColumn: "PostID");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_ApplicationUserID",
                table: "Post",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
