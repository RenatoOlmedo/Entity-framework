using Microsoft.EntityFrameworkCore.Migrations;

namespace LPsalut.Infrastructure.Data.Migrations
{
    public partial class atualização : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_NotaFiscals_NotaFiscalId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_NotaFiscalId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "NotaFiscalId",
                table: "Produtos");

            migrationBuilder.AddColumn<string>(
                name: "PRODUTOS",
                table: "NotaFiscals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "QUANTIDADE",
                table: "NotaFiscals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PRODUTOS",
                table: "NotaFiscals");

            migrationBuilder.DropColumn(
                name: "QUANTIDADE",
                table: "NotaFiscals");

            migrationBuilder.AddColumn<int>(
                name: "NotaFiscalId",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_NotaFiscalId",
                table: "Produtos",
                column: "NotaFiscalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_NotaFiscals_NotaFiscalId",
                table: "Produtos",
                column: "NotaFiscalId",
                principalTable: "NotaFiscals",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
