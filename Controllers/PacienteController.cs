using CitasApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Controllers
{
    public class PacienteController : Controller
    {
        private static List<Paciente> pacientes = new()
        {
            new Paciente
            {
                Id = 1,
                Nombre = "Juan",
                Apellido = "Pérez",
                Email = "juan@gmail.com",
                Telefono = "9991111111"
            },
            new Paciente
            {
                Id = 2,
                Nombre = "María",
                Apellido = "López",
                Email = "maria@gmail.com",
                Telefono = "9992222222"
            },
            new Paciente
            {
                Id = 3,
                Nombre = "Carlos",
                Apellido = "Ruiz",
                Email = "carlos@gmail.com",
                Telefono = "9993333333"
            }
        };

        public IActionResult Index()
        {
            return View(pacientes);
        }

        public IActionResult Detalle(int id)
        {
            var paciente = pacientes.FirstOrDefault(p => p.Id == id);

            if (paciente == null)
                return NotFound();

            return View(paciente);
        }
    }
}