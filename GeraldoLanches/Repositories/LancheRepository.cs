using GeraldoLanches.Context;
using GeraldoLanches.Models;
using GeraldoLanches.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GeraldoLanches.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext_context _context;

        public LancheRepository(AppDbContext_context contexto) 
        {
            _context = contexto;
        }

        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches.Where(l=> l.IsLanchePreferido).Include(c => c.Categoria);

        public Lanche GetLancheById(int lancheid)
        {
            return _context.Lanches.FirstOrDefault(l=>l.LancheId == lancheid);
        }
    }
}
