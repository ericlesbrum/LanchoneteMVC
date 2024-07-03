using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lanchonete.Migrations
{
    /// <inheritdoc />
    public partial class PopularLanches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO 
            Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,ImagemUrl,ImagemThumbnailUrl,IsLanchePreferido,EmEstoque,Nome,Preco) 
            VALUES(1,'DescricaoCurta','DescricaoDetalhada','ImagemUrl','ImagemThumbnailUrl',0,1,'Pão',12.50)");
            migrationBuilder.Sql(@"INSERT INTO 
            Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,ImagemUrl,ImagemThumbnailUrl,IsLanchePreferido,EmEstoque,Nome,Preco) 
            VALUES(1,'DescricaoCurta','DescricaoDetalhada','ImagemUrl','ImagemThumbnailUrl',0,1,'Pão',12.50)");
            migrationBuilder.Sql(@"INSERT INTO 
            Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,ImagemUrl,ImagemThumbnailUrl,IsLanchePreferido,EmEstoque,Nome,Preco) 
            VALUES(2,'DescricaoCurta','DescricaoDetalhada','ImagemUrl','ImagemThumbnailUrl',0,1,'Pão',12.50)");
            migrationBuilder.Sql(@"INSERT INTO 
            Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,ImagemUrl,ImagemThumbnailUrl,IsLanchePreferido,EmEstoque,Nome,Preco) 
            VALUES(2,'DescricaoCurta','DescricaoDetalhada','ImagemUrl','ImagemThumbnailUrl',1,1,'Pão',12.50)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Lanches");
        }
    }
}
