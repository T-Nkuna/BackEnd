using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class CreateForeignKeyInClientInvoices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ClientInvoices_ClientAccountId",
                table: "ClientInvoices",
                column: "ClientAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientInvoices_ClientAccounts_ClientAccountId",
                table: "ClientInvoices",
                column: "ClientAccountId",
                principalTable: "ClientAccounts",
                principalColumn: "ClientAccountId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientInvoices_ClientAccounts_ClientAccountId",
                table: "ClientInvoices");

            migrationBuilder.DropIndex(
                name: "IX_ClientInvoices_ClientAccountId",
                table: "ClientInvoices");
        }
    }
}
