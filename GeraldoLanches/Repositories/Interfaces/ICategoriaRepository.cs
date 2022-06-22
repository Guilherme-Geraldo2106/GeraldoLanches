using GeraldoLanches.Models;

namespace GeraldoLanches.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}
