using CitasApp.Domain.Interfaces;
using CitasApp.Infrastructure.Helpers;

namespace CitasApp.Infrastructure.Repositories
{
    public static class RepositoryFactory
    {
        public static IPacienteRepository CrearPacienteRepository(string entorno, JsonDataService dataService)
        {
            return entorno switch
            {
                "Production" => new MemoriaPacienteRepository(),
                _ => new JsonPacienteRepository(dataService)
            };
        }

        public static IMedicoRepository CrearMedicoRepository(string entorno, JsonDataService dataService)
        {
            return entorno switch
            {
                "Production" => new JsonMedicoRepository(dataService),
                _ => new JsonMedicoRepository(dataService)
            };
        }

        public static ICitaRepository CrearCitaRepository(string entorno, JsonDataService dataService)
        {
            return entorno switch
            {
                "Production" => new JsonCitaRepository(dataService),
                _ => new JsonCitaRepository(dataService)
            };
        }
    }
}