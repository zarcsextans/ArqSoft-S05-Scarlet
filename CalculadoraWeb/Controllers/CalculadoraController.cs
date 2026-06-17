using Microsoft.AspNetCore.Mvc;

namespace CalculadoraWeb.Controllers
{
    public class CalculadoraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
