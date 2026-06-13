using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;
using Microsoft.Data.Sqlite;

namespace CitasApp.Infrastructure.Repositories
{
    public class SqliteCitaRepository : ICitaRepository
    {
        private readonly string _connectionString;

        public SqliteCitaRepository(string dbPath)
        {
            _connectionString = $"Data Source={dbPath}";
            Inicializar();
            Seed();
        }

        private SqliteConnection Conectar()
        {
            var conn = new SqliteConnection(_connectionString);
            conn.Open();
            return conn;
        }

        private void Inicializar()
        {
            using var conn = Conectar();

            var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Citas (
                    Id INTEGER PRIMARY KEY,
                    PacienteId INTEGER,
                    MedicoId INTEGER,
                    Fecha TEXT,
                    Hora TEXT,
                    Motivo TEXT,
                    Estado TEXT
                );";

            cmd.ExecuteNonQuery();
        }

        private void Seed()
        {
            using var conn = Conectar();

            var check = conn.CreateCommand();
            check.CommandText = "SELECT COUNT(*) FROM Citas";

            long total = (long)check.ExecuteScalar();

            if (total > 0)
                return;

            var cmd = conn.CreateCommand();

            cmd.CommandText = @"
            INSERT INTO Citas VALUES (1,101,1,'2026-06-11','09:00','Control de rutina mensual','Pendiente');
            INSERT INTO Citas VALUES (2,102,2,'2026-06-11','10:30','Revisión de resultados de laboratorio','Pendiente');
            INSERT INTO Citas VALUES (3,103,1,'2026-06-11','11:15','Dolor de cabeza crónico y fatiga','Pendiente');
            INSERT INTO Citas VALUES (4,104,3,'2026-06-12','16:00','Consulta inicial por dolor lumbar','Pendiente');
            INSERT INTO Citas VALUES (5,105,2,'2026-06-12','17:30','Seguimiento de hipertensión','Pendiente');
            ";

            cmd.ExecuteNonQuery();
        }

        public List<Cita> ObtenerTodos()
        {
            using var conn = Conectar();

            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Citas";

            var lista = new List<Cita>();

            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                lista.Add(new Cita
                {
                    Id = r.GetInt32(0),
                    PacienteId = r.GetInt32(1),
                    MedicoId = r.GetInt32(2),
                    Fecha = DateOnly.Parse(r.GetString(3)),
                    Hora = TimeOnly.Parse(r.GetString(4)),
                    Motivo = r.GetString(5),
                    Estado = r.GetString(6)
                });
            }

            return lista;
        }

        public Cita? ObtenerPorId(int id)
        {
            return ObtenerTodos().FirstOrDefault(x => x.Id == id);
        }

        public List<Cita> ObtenerPorPaciente(int pacienteId)
        {
            return ObtenerTodos()
                .Where(x => x.PacienteId == pacienteId)
                .ToList();
        }

        public void Agregar(Cita cita)
        {
        }

        public void Actualizar(Cita cita)
        {
        }

        public void Eliminar(int id)
        {
        }
    }
}