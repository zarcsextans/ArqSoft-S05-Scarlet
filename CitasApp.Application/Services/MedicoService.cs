using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;

namespace CitasApp.Application.Services
{
    public class MedicoService
    {
        private readonly IMedicoRepository _repository;

        public MedicoService(IMedicoRepository repository)
        {
            _repository = repository;
        }

        public List<Medico> ObtenerTodos()
        {
            return _repository.ObtenerTodos();
        }
    }
}