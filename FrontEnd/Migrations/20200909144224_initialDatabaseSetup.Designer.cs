﻿// <auto-generated />
using System;
using ClientInvoicing.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClientInvoicing.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200909144224_initialDatabaseSetup")]
    partial class initialDatabaseSetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClientInvoicing.Models.ClientAccount", b =>
                {
                    b.Property<int>("ClientAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientAccountId");

                    b.ToTable("ClientAccounts");
                });

            modelBuilder.Entity("ClientInvoicing.Models.ClientInvoice", b =>
                {
                    b.Property<int>("ClientInvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientAccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("InvoiceAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("InvoiceLasPaidAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("InvoiceLastPaidOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("InvoiceOwedAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("InvoicePaid")
                        .HasColumnType("bit");

                    b.HasKey("ClientInvoiceId");

                    b.ToTable("ClientInvoices");
                });
#pragma warning restore 612, 618
        }
    }
}
