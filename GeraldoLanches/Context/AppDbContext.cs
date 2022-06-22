using GeraldoLanches.Models;
using Microsoft.EntityFrameworkCore;

namespace GeraldoLanches.Context
{
    public class AppDbContext_context : DbContext
    {
        public AppDbContext_context(DbContextOptions<AppDbContext_context> options) : base(options)
        {
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

    }
}
