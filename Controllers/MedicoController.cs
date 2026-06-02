using Microsoft.AspNetCore.Mvc;
using TuProyecto.Data;
using Microsoft.EntityFrameworkCore;

public class MedicoController : Controller
{
    private readonly ApplicationDbContext _context;

    public MedicoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Lista todos los médicos
    public IActionResult Index()
    {
        var medicos = _context.Medicos.ToList();
        return View(medicos);
    }

    // Muestra detalle y especialidad
    public IActionResult Detalle(int id)
    {
        var medico = _context.Medicos
            .Include(m => m.Especialidad)
            .FirstOrDefault(m => m.Id == id);

        if (medico == null)
            return NotFound();

        return View(medico);
    }
}