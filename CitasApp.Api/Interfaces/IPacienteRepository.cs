using CitasApp.Domain.Models;

namespace CitasApp.Domain.Interfaces
{
    public interface IPacienteRepository
    {
        List<Paciente> ObtenerTodos();
        Paciente? ObtenerPorId(int id);

        void Agregar(Paciente p);
        void Actualizar(Paciente p);
        void Eliminar(int id);
    }
}