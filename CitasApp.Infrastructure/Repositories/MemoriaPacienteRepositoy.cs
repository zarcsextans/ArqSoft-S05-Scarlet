using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;

namespace CitasApp.Infrastructure.Repositories
{
    public class MemoriaPacienteRepository : IPacienteRepository
    {
        private readonly List<Paciente> _pacientes = new();
        private int _nextId = 1;

        public List<Paciente> ObtenerTodos()
        {
            return _pacientes;
        }

        public Paciente? ObtenerPorId(int id)
        {
            return _pacientes.FirstOrDefault(p => p.Id == id);
        }

        public void Agregar(Paciente p)
        {
            p.Id = _nextId++;
            _pacientes.Add(p);
        }

        public void Actualizar(Paciente p)
        {
            var existente = _pacientes.FirstOrDefault(x => x.Id == p.Id);
            if (existente == null) return;

            existente.Nombre = p.Nombre;
            existente.Edad = p.Edad;
            existente.Telefono = p.Telefono;
        }

        public void Eliminar(int id)
        {
            var paciente = _pacientes.FirstOrDefault(x => x.Id == id);
            if (paciente != null)
            {
                _pacientes.Remove(paciente);
            }
        }
    }
}