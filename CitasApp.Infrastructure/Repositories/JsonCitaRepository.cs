using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;
using CitasApp.Infrastructure.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CitasApp.Infrastructure.Repositories
{
    public class JsonCitaRepository : ICitaRepository
    {
        private readonly string _path;

        public JsonCitaRepository(JsonDataService dataService)
        {
            _path = dataService.GetCitasPath();
            if (!File.Exists(_path))
            {
                File.WriteAllText(_path, JsonSerializer.Serialize(new List<Cita>()));
            }
        }

        public List<Cita> ObtenerTodos()
        {
            var json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<Cita>>(json) ?? new List<Cita>();
        }

        public Cita? ObtenerPorId(int id)
        {
            foreach (var c in ObtenerTodos()) if (c.Id == id) return c;
            return null;
        }

        public void Agregar(Cita entity)
        {
            var list = new List<Cita>(ObtenerTodos());
            entity.Id = list.Count > 0 ? list[list.Count - 1].Id + 1 : 1;
            list.Add(entity);
            File.WriteAllText(_path, JsonSerializer.Serialize(list));
        }

        public List<Cita> ObtenerPorPaciente(int pacienteId)
        {
            var list = ObtenerTodos();
            return list.FindAll(c => c.PacienteId == pacienteId);
        }

        public void Actualizar(Cita cita)
        {
            var list = new List<Cita>(ObtenerTodos());
            var idx = list.FindIndex(x => x.Id == cita.Id);
            if (idx >= 0) list[idx] = cita;
            File.WriteAllText(_path, JsonSerializer.Serialize(list));
        }

        public void Eliminar(int id)
        {
            var list = new List<Cita>(ObtenerTodos());
            list.RemoveAll(x => x.Id == id);
            File.WriteAllText(_path, JsonSerializer.Serialize(list));
        }
    }
}