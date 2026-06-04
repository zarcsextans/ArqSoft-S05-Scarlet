using CitasApp.Models;
using CitasApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Controllers
{
    public class CitaController : Controller
    {
        private readonly JsonDataService _json;

        public CitaController(JsonDataService json)
        {
            _json = json;
        }

        public IActionResult Index()
        {
            var citas = _json.Leer<Cita>("Data/citas.json");

            ViewBag.Pacientes =
                _json.Leer<Paciente>("Data/pacientes.json");

            ViewBag.Medicos =
                _json.Leer<Medico>("Data/medicos.json");

            return View(citas);
        }

        public IActionResult PorPaciente(int pacienteId)
        {
            var citas = _json.Leer<Cita>("Data/citas.json");

            var resultado = citas
                .Where(c => c.PacienteId == pacienteId)
                .ToList();

            ViewBag.Pacientes =
                _json.Leer<Paciente>("Data/pacientes.json");

            ViewBag.Medicos =
                _json.Leer<Medico>("Data/medicos.json");

            return View(resultado);
        }
    }
}