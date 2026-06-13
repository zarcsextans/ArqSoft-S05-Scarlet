using CitasApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Web.Controllers
{
    public class PacienteController : Controller
    {
        private readonly PacienteService _service;

        public PacienteController(PacienteService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var pacientes = _service.ObtenerTodos();
            return View(pacientes);
        }
    }
}