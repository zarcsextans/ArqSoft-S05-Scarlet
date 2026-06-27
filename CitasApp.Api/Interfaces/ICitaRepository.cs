using CitasApp.Domain.Models;

namespace CitasApp.Domain.Interfaces
{
    public interface ICitaRepository
    {
        List<Cita> ObtenerTodos();
        Cita? ObtenerPorId(int id);
        List<Cita> ObtenerPorPaciente(int pacienteId);

        void Agregar(Cita cita);
        void Actualizar(Cita cita);
        void Eliminar(int id);
    }
}