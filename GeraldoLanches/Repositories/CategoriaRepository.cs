using GeraldoLanches.Context;
using GeraldoLanches.Models;
using GeraldoLanches.Repositories.Interfaces;

namespace GeraldoLanches.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext_context  _context;

        public CategoriaRepository(AppDbContext_context contexto)
        {
            _context = contexto;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
