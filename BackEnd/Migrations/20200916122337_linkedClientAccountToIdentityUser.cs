using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class linkedClientAccountToIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ClientAccounts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientAccounts_UserId",
                table: "ClientAccounts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientAccounts_AspNetUsers_UserId",
                table: "ClientAccounts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientAccounts_AspNetUsers_UserId",
                table: "ClientAccounts");

            migrationBuilder.DropIndex(
                name: "IX_ClientAccounts_UserId",
                table: "ClientAccounts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ClientAccounts");
        }
    }
}
