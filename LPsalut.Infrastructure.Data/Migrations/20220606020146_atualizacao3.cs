using Microsoft.EntityFrameworkCore.Migrations;

namespace LPsalut.Infrastructure.Data.Migrations
{
    public partial class atualizacao3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "NotaFiscals",
                type: "varchar(30000000)",
                maxLength: 30000000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "NotaFiscals",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30000000)",
                oldMaxLength: 30000000);
        }
    }
}
