using CitasApp.Models;
using CitasApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Controllers
{
    public class PacienteController : Controller
    {
        private readonly JsonDataService _json;

        public PacienteController(JsonDataService json)
        {
            _json = json;
        }

        public IActionResult Index()
        {
            var pacientes = _json.Leer<Paciente>("Data/pacientes.json");
            return View(pacientes);
        }
    }
}