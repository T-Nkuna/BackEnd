using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientInvoicing.Migrations
{
    public partial class initialDatabaseSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientAccounts",
                columns: table => new
                {
                    ClientAccountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientAccounts", x => x.ClientAccountId);
                });

            migrationBuilder.CreateTable(
                name: "ClientInvoices",
                columns: table => new
                {
                    ClientInvoiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    InvoicePaid = table.Column<bool>(nullable: false),
                    InvoiceAmount = table.Column<decimal>(nullable: false),
                    InvoiceOwedAmount = table.Column<decimal>(nullable: false),
                    InvoiceLasPaidAmount = table.Column<decimal>(nullable: false),
                    InvoiceLastPaidOn = table.Column<DateTime>(nullable: true),
                    ClientAccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientInvoices", x => x.ClientInvoiceId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientAccounts");

            migrationBuilder.DropTable(
                name: "ClientInvoices");
        }
    }
}
