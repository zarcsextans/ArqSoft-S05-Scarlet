using CitasApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Web.Controllers
{
    public class MedicoController : Controller
    {
        private readonly MedicoService _service;

        public MedicoController(MedicoService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var medicos = _service.ObtenerTodos();
            return View(medicos);
        }
    }
}