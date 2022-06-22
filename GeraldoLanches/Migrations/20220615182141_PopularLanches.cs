using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeraldoLanches.Migrations
{
    public partial class PopularLanches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId, Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnailUrl, IsLanchePreferido, EmEstoque)" +
                "VALUES (1, 'X-Bacon', 'Pão de Brioche, maionese caseira, hamburguer artesanal, mussarela e bacon', 'Delicioso lanche com hamburguer de costela 250g artesaal, maionese de alho da casa,4 fatias de queijo mussarela, e bancon crocante em tiras', 25.90, 'https://uploaddeimagens.com.br/images/003/906/820/original/xbacon.jpg?1655480047', 'https://uploaddeimagens.com.br/images/003/906/820/original/xbacon.jpg?1655480047', 1, 1)");

            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId, Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnailUrl, IsLanchePreferido, EmEstoque)" +
                "VALUES (1, 'X-Frango', 'Pão de Brioche, maionese caseira, Frango Desfiado, mussarela e cebola caramelizada', 'Delicioso lanche com frango desfiado e cremoso com catupiry original, maionese de alho da casa,4 fatias de queijo mussarela, e cebola caramelizada', 21.90, 'https://uploaddeimagens.com.br/images/003/906/824/original/xfrango.jpg?1655480202', 'https://uploaddeimagens.com.br/images/003/906/824/original/xfrango.jpg?1655480202', 0, 1)");

            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId, Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnailUrl, IsLanchePreferido, EmEstoque)" +
                "VALUES (2, 'Sanduiche de Atum', 'Pão de forma, maionese caseira, pate de atum', 'Delicioso lanche saudavel, com cremoso pate de atum, e maionese de alho da casa', 11.90, 'https://uploaddeimagens.com.br/images/003/906/822/original/naturalatum.jpg?1655480138', 'https://uploaddeimagens.com.br/images/003/906/822/original/naturalatum.jpg?1655480138', 0, 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Lanches");
        }
    }
}
