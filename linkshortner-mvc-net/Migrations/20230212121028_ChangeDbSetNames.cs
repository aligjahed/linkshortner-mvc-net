using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace linkshortner_mvc_net.Migrations
{
    public partial class ChangeDbSetNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Urls_Users_UserId",
                table: "Urls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Urls",
                table: "Urls");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "LinkshortnerUsers");

            migrationBuilder.RenameTable(
                name: "Urls",
                newName: "LinkshortnerUrls");

            migrationBuilder.RenameIndex(
                name: "IX_Urls_UserId",
                table: "LinkshortnerUrls",
                newName: "IX_LinkshortnerUrls_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinkshortnerUsers",
                table: "LinkshortnerUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinkshortnerUrls",
                table: "LinkshortnerUrls",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkshortnerUrls_LinkshortnerUsers_UserId",
                table: "LinkshortnerUrls",
                column: "UserId",
                principalTable: "LinkshortnerUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkshortnerUrls_LinkshortnerUsers_UserId",
                table: "LinkshortnerUrls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LinkshortnerUsers",
                table: "LinkshortnerUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LinkshortnerUrls",
                table: "LinkshortnerUrls");

            migrationBuilder.RenameTable(
                name: "LinkshortnerUsers",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "LinkshortnerUrls",
                newName: "Urls");

            migrationBuilder.RenameIndex(
                name: "IX_LinkshortnerUrls_UserId",
                table: "Urls",
                newName: "IX_Urls_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Urls",
                table: "Urls",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Urls_Users_UserId",
                table: "Urls",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
