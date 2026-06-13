using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CitasApp.Infrastructure.Repositories
{
    public class CsvMedicoRepository : IMedicoRepository
    {
        private readonly string _filePath;

        public CsvMedicoRepository(string filePath)
        {
            _filePath = filePath;

            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath,
                    "Id,Nombre,Apellido,Especialidad,NumeroLicencia\n");
            }
        

        public List<Medico> ObtenerTodos()
        {
            if (!File.Exists(_filePath))
                return new List<Medico>();

            return File.ReadAllLines(_filePath)
                .Skip(1)
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(l =>
                {
                    var p = l.Split(',');

                    return new Medico
                    {
                        Id = int.Parse(p[0]),
                        Nombre = p[1],
                        Apellido = p[2],
                        Especialidad = p[3],
                        NumeroLicencia = p[4]
                    };
                })
                .ToList();
        }

        public Medico? ObtenerPorId(int id)
            => ObtenerTodos().FirstOrDefault(x => x.Id == id);

        public void Agregar(Medico medico)
        {
            var lista = ObtenerTodos();
            medico.Id = lista.Count == 0 ? 1 : lista.Max(x => x.Id) + 1;
            lista.Add(medico);
            Guardar(lista);
        }

        public void Actualizar(Medico medico)
        {
            var lista = ObtenerTodos();
            var i = lista.FindIndex(x => x.Id == medico.Id);

            if (i >= 0)
            {
                lista[i] = medico;
                Guardar(lista);
            }
        }

        public void Eliminar(int id)
        {
            var lista = ObtenerTodos();
            lista.RemoveAll(x => x.Id == id);
            Guardar(lista);
        }

        private void Guardar(List<Medico> lista)
        {
            var lines = new List<string>
            {
                "Id,Nombre,Apellido,Especialidad,NumeroLicencia"
            };

            lines.AddRange(lista.Select(m =>
                $"{m.Id},{m.Nombre},{m.Apellido},{m.Especialidad},{m.NumeroLicencia}"
            ));

            File.WriteAllLines(_filePath, lines);
        }
    }
}