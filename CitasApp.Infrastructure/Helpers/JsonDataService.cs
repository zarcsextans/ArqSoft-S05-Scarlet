namespace CitasApp.Infrastructure.Helpers
{
    public class JsonDataService
    {
        private readonly string _dataFolder;

        public JsonDataService(string dataFolder)
        {
            _dataFolder = dataFolder;
        }

        public string GetPacientesPath() =>
            Path.Combine(_dataFolder, "pacientes.json");

        public string GetMedicosPath() =>
            Path.Combine(_dataFolder, "medicos.json");

        public string GetCitasPath() =>
            Path.Combine(_dataFolder, "citas.json");
    }
}