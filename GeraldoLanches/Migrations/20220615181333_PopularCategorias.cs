using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeraldoLanches.Migrations
{
    public partial class PopularCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao)" + "VALUES ('Normal', 'Lanche com ingredientes normais')");

            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao)" + "VALUES ('Integral', 'Lanche com ingredientes Integral')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
