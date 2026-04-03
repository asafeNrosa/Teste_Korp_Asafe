using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProdutosApi.Migrations
{
    /// <inheritdoc />
    public partial class AjusteProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "Produtos",
                newName: "Descricao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Produtos",
                newName: "descricao");
        }
    }
}
