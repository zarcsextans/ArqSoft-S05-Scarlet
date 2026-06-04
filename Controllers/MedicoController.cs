using CitasApp.Models;
using CitasApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Controllers
{
    public class MedicoController : Controller
    {
        private readonly JsonDataService _json;

        public MedicoController(JsonDataService json)
        {
            _json = json;
        }

        public IActionResult Index()
        {
            var medicos = _json.Leer<Medico>("Data/medicos.json");
            return View(medicos);
        }
    }
}