using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CitasApp.Infrastructure.Repositories
{
    public class CsvPacienteRepository : IPacienteRepository
    {
        private readonly string _filePath;

        public CsvPacienteRepository(string filePath)
        {
            _filePath = filePath;

            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath,
                    "Id,Nombre,Apellido,Email,Telefono\n");
        }

        public List<Paciente> ObtenerTodos()
        {
            if (!File.Exists(_filePath))
                return new List<Paciente>();

            return File.ReadAllLines(_filePath)
                .Skip(1)
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(l =>
                {
                    var p = l.Split(',');

                    return new Paciente
                    {
                        Id = int.Parse(p[0]),
                        Nombre = p[1],
                        Apellido = p[2],
                        Email = p[3],
                        Telefono = p[4]
                    };
                })
                .ToList();
        }

        public Paciente? ObtenerPorId(int id)
            => ObtenerTodos().FirstOrDefault(x => x.Id == id);

        public void Agregar(Paciente paciente)
        {
            var lista = ObtenerTodos();
            paciente.Id = lista.Count == 0 ? 1 : lista.Max(x => x.Id) + 1;
            lista.Add(paciente);
            Guardar(lista);
        }

        public void Actualizar(Paciente paciente)
        {
            var lista = ObtenerTodos();
            var i = lista.FindIndex(x => x.Id == paciente.Id);

            if (i >= 0)
            {
                lista[i] = paciente;
                Guardar(lista);
            }
        }

        public void Eliminar(int id)
        {
            var lista = ObtenerTodos();
            lista.RemoveAll(x => x.Id == id);
            Guardar(lista);
        }

        private void Guardar(List<Paciente> lista)
        {
            var lines = new List<string>
            {
                "Id,Nombre,Apellido,Email,Telefono"
            };

            lines.AddRange(lista.Select(p =>
                $"{p.Id},{p.Nombre},{p.Apellido},{p.Email},{p.Telefono}"
            ));

            File.WriteAllLines(_filePath, lines);
        }
    }
}