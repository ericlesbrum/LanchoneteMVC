using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lanchonete.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO Categoria(CategoriaNome,Descricao)
            VALUES('Normal','Lacnhes feito com ingredientes normais')");

            migrationBuilder.Sql(@"INSERT INTO Categoria(CategoriaNome,Descricao)
            VALUES('Natural','Lacnhes feito com ingredientes integrais e naturais')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categoria");
        }
    }
}
