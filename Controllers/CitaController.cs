using CitasApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

public class CitaController : Controller
{
    private static List<Paciente> pacientes = new List<Paciente>
    {
        new Paciente { Id = 1, NombreCompleto = "Juan Pérez", Email = "juan@gmail.com" },
        new Paciente { Id = 2, NombreCompleto = "María López", Email = "maria@gmail.com" },
        new Paciente { Id = 3, NombreCompleto = "Carlos Ruiz", Email = "carlos@gmail.com" }
    };

    private static List<Medico> medicos = new List<Medico>
    {
        new Medico { Id = 1, NombreCompleto = "Dra. Ana López", Especialidad = "Medicina General" },
        new Medico { Id = 2, NombreCompleto = "Dr. Pedro García", Especialidad = "Cardiología" }
    };

    private static List<Cita> citas = new List<Cita>
    {
        new Cita
        {
            Id = 1,
            PacienteId = 1,
            MedicoId = 1,
            Fecha = new DateTime(2026, 6, 1),
            FechaHora = "09:00",
            Motivo = "Consulta general",
            Estado = "Confirmada"
        },
        new Cita
        {
            Id = 2,
            PacienteId = 2,
            MedicoId = 2,
            Fecha = new DateTime(2026, 6, 1),
            FechaHora = "10:00",
            Motivo = "Revisión de resultados",
            Estado = "Pendiente"
        },
        new Cita
        {
            Id = 3,
            PacienteId = 3,
            MedicoId = 1,
            Fecha = new DateTime(2026, 6, 3),
            FechaHora = "11:00",
            Motivo = "Primera consulta",
            Estado = "Pendiente"
        }
    };

    public IActionResult Index()
    {
        var resultado = citas.Select(c => new CitaViewModel
        {
            Fecha = c.Fecha,
            FechaHora = c.FechaHora,
            NombrePaciente = pacientes
                .FirstOrDefault(p => p.Id == c.PacienteId)?.NombreCompleto,
            NombreMedico = medicos
                .FirstOrDefault(m => m.Id == c.MedicoId)?.NombreCompleto,
            Motivo = c.Motivo,
            Estado = c.Estado
        }).ToList();

        return View(resultado);
    }

    public IActionResult PorPaciente(int pacienteId)
    {
        var resultado = citas
            .Where(c => c.PacienteId == pacienteId)
            .Select(c => new CitaViewModel
            {
                Fecha = c.Fecha,
                FechaHora = c.FechaHora,
                NombrePaciente = pacientes
                    .FirstOrDefault(p => p.Id == c.PacienteId)?.NombreCompleto,
                NombreMedico = medicos
                    .FirstOrDefault(m => m.Id == c.MedicoId)?.NombreCompleto,
                Motivo = c.Motivo,
                Estado = c.Estado
            }).ToList();

        return View(resultado);
    }
}