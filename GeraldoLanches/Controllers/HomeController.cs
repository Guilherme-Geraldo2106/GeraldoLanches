using GeraldoLanches.Models;
using GeraldoLanches.Repositories.Interfaces;
using GeraldoLanches.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GeraldoLanches.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILancheRepository _lancherepository;

        public HomeController(ILancheRepository lancherepository)
        {
            _lancherepository = lancherepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel 
            { 
                LanchesPreferidos = _lancherepository.LanchesPreferidos 
            };

            return View(homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}