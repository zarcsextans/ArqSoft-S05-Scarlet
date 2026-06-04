using System.Text.Json;

namespace CitasApp.Services
{
    public class JsonDataService
    {
        public List<T> Leer<T>(string archivo)
        {
            if (!System.IO.File.Exists(archivo))
                return new List<T>();

            string json = System.IO.File.ReadAllText(archivo);

            return JsonSerializer.Deserialize<List<T>>(json)
                   ?? new List<T>();
        }
    }
}