using Microsoft.AspNetCore.Mvc;

namespace GeraldoLanches.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
