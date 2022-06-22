using GeraldoLanches.Models;
using GeraldoLanches.Repositories.Interfaces;
using GeraldoLanches.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GeraldoLanches.Controllers
{
    public class LancheController : Controller
    {

        private readonly ILancheRepository _LancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _LancheRepository = lancheRepository;
        }

        public  IActionResult list (string categoria)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;
            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _LancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os Lanches";
                
            }
            else
            {
                if (string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _LancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals("Normal"))
                                                       .OrderBy(l => l.Nome);
                    categoriaAtual = categoria;

                }
                else if(string.Equals("Integral", categoria, StringComparison.OrdinalIgnoreCase))
                {  
                    lanches = _LancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals("Integral"))
                                                           .OrderBy(l => l.Nome);
                    categoriaAtual = categoria;
                }
                else
                {
                    lanches = null;
                    categoriaAtual = null;
                }

                
            }

            var lancheslistviewmodel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lancheslistviewmodel);
        }
    }
}
