using CitasApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CitasApp.Controllers
{
    public class CitaController : Controller
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

        private static List<Cita> citas = new()
        {
            new Cita
            {
                Id = 1,
                PacienteId = 1,
                MedicoId = 1,
                Fecha = new DateOnly(2026, 6, 1),
                Hora = new TimeOnly(9, 0),
                Motivo = "Consulta general",
                Estado = "Confirmada"
            },
            new Cita
            {
                Id = 2,
                PacienteId = 2,
                MedicoId = 2,
                Fecha = new DateOnly(2026, 6, 1),
                Hora = new TimeOnly(10, 0),
                Motivo = "Revisión de resultados",
                Estado = "Pendiente"
            },
            new Cita
            {
                Id = 3,
                PacienteId = 3,
                MedicoId = 1,
                Fecha = new DateOnly(2026, 6, 3),
                Hora = new TimeOnly(11, 0),
                Motivo = "Primera consulta",
                Estado = "Pendiente"
            }
        };

        public IActionResult Index()
        {
            ViewBag.Pacientes = pacientes;
            ViewBag.Medicos = medicos;

            return View(citas);
        }

        public IActionResult PorPaciente(int pacienteId)
        {
            var resultado = citas
                .Where(c => c.PacienteId == pacienteId)
                .ToList();

            ViewBag.Pacientes = pacientes;
            ViewBag.Medicos = medicos;

            return View(resultado);
        }
    }
}