using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;

namespace CitasApp.Application.Services
{
    public class PacienteService
    {
        private readonly IPacienteRepository _repository;

        public PacienteService(IPacienteRepository repository)
        {
            _repository = repository;
        }

        public List<Paciente> ObtenerTodos()
        {
            return _repository.ObtenerTodos();
        }

        public Paciente? ObtenerPorId(int id)
        {
            return _repository.ObtenerPorId(id);
        }
    }
}