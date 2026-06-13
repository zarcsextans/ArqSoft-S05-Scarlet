using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;
using CitasApp.Infrastructure.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CitasApp.Infrastructure.Repositories
{
    public class JsonMedicoRepository : IMedicoRepository
    {
        private readonly string _path;

        public JsonMedicoRepository(JsonDataService dataService)
        {
            _path = dataService.GetMedicosPath();
            if (!File.Exists(_path))
            {
                File.WriteAllText(_path, JsonSerializer.Serialize(new List<Medico>()));
            }
        }

        public List<Medico> ObtenerTodos()
        {
            var json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<Medico>>(json) ?? new List<Medico>();
        }

        public Medico? ObtenerPorId(int id)
        {
            foreach (var m in ObtenerTodos()) if (m.Id == id) return m;
            return null;
        }

        public void Agregar(Medico entity)
        {
            var list = new List<Medico>(ObtenerTodos());
            entity.Id = list.Count > 0 ? list[list.Count - 1].Id + 1 : 1;
            list.Add(entity);
            File.WriteAllText(_path, JsonSerializer.Serialize(list));
        }

        public void Actualizar(Medico medico)
        {
            var list = new List<Medico>(ObtenerTodos());
            var idx = list.FindIndex(x => x.Id == medico.Id);
            if (idx >= 0) list[idx] = medico;
            File.WriteAllText(_path, JsonSerializer.Serialize(list));
        }

        public void Eliminar(int id)
        {
            var list = new List<Medico>(ObtenerTodos());
            list.RemoveAll(x => x.Id == id);
            File.WriteAllText(_path, JsonSerializer.Serialize(list));
        }
    }
}