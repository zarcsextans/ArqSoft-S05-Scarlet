using CitasApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Web.Controllers
{
    public class CitaController : Controller
    {
        private readonly CitaService _citaService;
        private readonly PacienteService _pacienteService;
        private readonly MedicoService _medicoService;

        public CitaController(
            CitaService citaService,
            PacienteService pacienteService,
            MedicoService medicoService)
        {
            _citaService = citaService;
            _pacienteService = pacienteService;
            _medicoService = medicoService;
        }

        public IActionResult Index()
        {
            var citas = _citaService.ObtenerTodos();

            CargarCatalogos();

            return View(citas);
        }
        public IActionResult PorPaciente(int pacienteId)
        {
            var resultado = _citaService.ObtenerPorPaciente(pacienteId);

            CargarCatalogos();

            return View(resultado);
        }
        private void CargarCatalogos()
        {
            ViewBag.Pacientes = _pacienteService.ObtenerTodos();
            ViewBag.Medicos = _medicoService.ObtenerTodos();
        }
    }
}