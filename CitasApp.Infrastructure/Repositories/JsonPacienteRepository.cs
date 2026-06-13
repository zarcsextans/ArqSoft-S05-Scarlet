using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;
using CitasApp.Infrastructure.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CitasApp.Infrastructure.Repositories
{
    public class JsonPacienteRepository : IPacienteRepository
    {
        private readonly string _path;

        public JsonPacienteRepository(JsonDataService dataService)
        {
            _path = dataService.GetPacientesPath();
            if (!File.Exists(_path))
            {
                File.WriteAllText(_path, JsonSerializer.Serialize(new List<Paciente>()));
            }
        }

        public List<Paciente> ObtenerTodos()
        {
            var json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<Paciente>>(json) ?? new List<Paciente>();
        }

        public Paciente? ObtenerPorId(int id)
        {
            foreach (var p in ObtenerTodos()) if (p.Id == id) return p;
            return null;
        }

        public void Agregar(Paciente entity)
        {
            var list = new List<Paciente>(ObtenerTodos());
            entity.Id = list.Count > 0 ? list[list.Count - 1].Id + 1 : 1;
            list.Add(entity);
            File.WriteAllText(_path, JsonSerializer.Serialize(list));
        }

        public void Actualizar(Paciente p)
        {
            var list = new List<Paciente>(ObtenerTodos());
            var idx = list.FindIndex(x => x.Id == p.Id);
            if (idx >= 0) list[idx] = p;
            File.WriteAllText(_path, JsonSerializer.Serialize(list));
        }

        public void Eliminar(int id)
        {
            var list = new List<Paciente>(ObtenerTodos());
            list.RemoveAll(x => x.Id == id);
            File.WriteAllText(_path, JsonSerializer.Serialize(list));
        }
    }
}