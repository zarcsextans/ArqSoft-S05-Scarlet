using CitasApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Controllers
{
    public class MedicoController : Controller
    {
        private static List<Medico> medicos = new()
        {
            new Medico
            {
                Id = 1,
                Nombre = "Ana",
                Apellido = "López",
                Especialidad = "Medicina General",
                NumeroLicencia = "MED001"
            },
            new Medico
            {
                Id = 2,
                Nombre = "Pedro",
                Apellido = "García",
                Especialidad = "Cardiología",
                NumeroLicencia = "MED002"
            }
        };

        public IActionResult Index()
        {
            return View(medicos);
        }

        public IActionResult Detalle(int id)
        {
            var medico = medicos.FirstOrDefault(m => m.Id == id);

            if (medico == null)
                return NotFound();

            return View(medico);
        }
    }
}