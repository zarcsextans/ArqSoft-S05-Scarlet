using Microsoft.AspNetCore.Mvc;
using TuProyecto.Data;
using Microsoft.EntityFrameworkCore;

public class PacienteController : Controller
{
    private readonly ApplicationDbContext _context;

    public PacienteController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Lista todos los pacientes
    public IActionResult Index()
    {
        var pacientes = _context.Pacientes.ToList();
        return View(pacientes);
    }

    // Muestra el detalle de un paciente
    public IActionResult Detalle(int id)
    {
        var paciente = _context.Pacientes
            .FirstOrDefault(p => p.Id == id);

        if (paciente == null)
            return NotFound();

        return View(paciente);
    }
}