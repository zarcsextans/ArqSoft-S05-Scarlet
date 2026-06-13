using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CitasApp.Infrastructure.Repositories
{
    public class CsvCitaRepository : ICitaRepository
    {
        private readonly string _filePath;

        public CsvCitaRepository(string filePath)
        {
            _filePath = filePath;

            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath,
                    "Id,PacienteId,MedicoId,Fecha,Hora,Motivo,Estado\n");
            }
        }

        public List<Cita> ObtenerTodos()
        {
            if (!File.Exists(_filePath))
                return new List<Cita>();

            return File.ReadAllLines(_filePath)
                .Skip(1)
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(line =>
                {
                    var p = line.Split(',');

                    if (p.Length < 7)
                        return null;

                    return new Cita
                    {
                        Id = int.Parse(p[0]),
                        PacienteId = int.Parse(p[1]),
                        MedicoId = int.Parse(p[2]),
                        Fecha = DateOnly.Parse(p[3]),
                        Hora = TimeOnly.Parse(p[4]),
                        Motivo = p[5],
                        Estado = p[6]
                    };
                })
                .Where(c => c != null)
                .ToList()!;
        }

        public Cita? ObtenerPorId(int id)
        {
            return ObtenerTodos()
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Cita> ObtenerPorPaciente(int pacienteId)
        {
            return ObtenerTodos()
                .Where(x => x.PacienteId == pacienteId)
                .ToList();
        }

        public void Agregar(Cita cita)
        {
            var lista = ObtenerTodos();

            cita.Id = lista.Count == 0
                ? 1
                : lista.Max(x => x.Id) + 1;

            lista.Add(cita);

            Guardar(lista);
        }

        public void Actualizar(Cita cita)
        {
            var lista = ObtenerTodos();
            var index = lista.FindIndex(x => x.Id == cita.Id);

            if (index != -1)
            {
                lista[index] = cita;
                Guardar(lista);
            }
        }

        public void Eliminar(int id)
        {
            var lista = ObtenerTodos();

            lista.RemoveAll(x => x.Id == id);

            Guardar(lista);
        }

        private void Guardar(List<Cita> lista)
        {
            var lines = new List<string>
            {
                "Id,PacienteId,MedicoId,Fecha,Hora,Motivo,Estado"
            };

            lines.AddRange(lista.Select(c =>
                $"{c.Id},{c.PacienteId},{c.MedicoId},{c.Fecha:yyyy-MM-dd},{c.Hora},{c.Motivo},{c.Estado}"
            ));

            File.WriteAllLines(_filePath, lines);
        }
    }
}