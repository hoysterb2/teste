using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "REPORTS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DEBIT_AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CREDIT_AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REPORTS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TRANSACTIONS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DATE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TRANSACTION_TYPE = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSACTIONS", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "REPORTS");

            migrationBuilder.DropTable(
                name: "TRANSACTIONS");
        }
    }
}
