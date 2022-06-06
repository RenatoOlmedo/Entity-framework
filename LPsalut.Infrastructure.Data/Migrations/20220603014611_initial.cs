using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LPsalut.Infrastructure.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotaFiscals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VALOR_TOTAL = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    CNPJ = table.Column<int>(type: "int", nullable: false),
                    N_CUPOM = table.Column<int>(type: "int", nullable: false),
                    CANAL_COMPRA = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    DATA_COMPRA = table.Column<DateTime>(type: "date", nullable: false),
                    IMG_NF = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscals", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    PRECO = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    NotaFiscalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Produtos_NotaFiscals_NotaFiscalId",
                        column: x => x.NotaFiscalId,
                        principalTable: "NotaFiscals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_NotaFiscalId",
                table: "Produtos",
                column: "NotaFiscalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "NotaFiscals");
        }
    }
}
