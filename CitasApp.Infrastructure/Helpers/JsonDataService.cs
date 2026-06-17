using System.Text.Json;

namespace CitasApp.Infrastructure.Helpers
{
    public class JsonDataService
    {
        private readonly string _dataPath;

        public JsonDataService(string dataPath)
        {
            _dataPath = dataPath;
        }

        // Rutas de archivos JSON
        public string GetPacientesPath()
        {
            return Path.Combine(_dataPath, "pacientes.json");
        }

        public string GetMedicosPath()
        {
            return Path.Combine(_dataPath, "medicos.json");
        }

        public string GetCitasPath()
        {
            return Path.Combine(_dataPath, "citas.json");
        }

        // Leer archivo JSON genérico
        public List<T> LeerArchivo<T>(string fileName)
        {
            var path = Path.Combine(_dataPath, fileName);

            if (!File.Exists(path))
                return new List<T>();

            var json = File.ReadAllText(path);

            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        // Guardar archivo JSON genérico
        public void GuardarArchivo<T>(string fileName, List<T> data)
        {
            var path = Path.Combine(_dataPath, fileName);

            var json = JsonSerializer.Serialize(
                data,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(path, json);
        }
    }
}