using Microsoft.AspNetCore.Mvc;

namespace GeraldoLanches.Models
{
    public class TesteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Demo()
        {
            return View();
        }
    }
}
