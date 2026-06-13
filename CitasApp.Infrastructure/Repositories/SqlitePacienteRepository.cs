using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;
using Microsoft.Data.Sqlite;

namespace CitasApp.Infrastructure.Repositories
{
    public class SqlitePacienteRepository : IPacienteRepository
    {
        private readonly string _connectionString;

        public SqlitePacienteRepository(string dbPath)
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
                CREATE TABLE IF NOT EXISTS Pacientes (
                    Id INTEGER PRIMARY KEY,
                    Nombre TEXT NOT NULL,
                    Apellido TEXT NOT NULL,
                    Email TEXT,
                    Telefono TEXT
                );";
            cmd.ExecuteNonQuery();
        }

        private void Seed()
        {
            using var conn = Conectar();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
            INSERT INTO Pacientes (Id,Nombre,Apellido,Email,Telefono)
            SELECT 101,'Carlos','García','carlos.garcia@example.com','+525551234567'
            WHERE NOT EXISTS (SELECT 1 FROM Pacientes WHERE Id = 101);

            INSERT INTO Pacientes (Id,Nombre,Apellido,Email,Telefono)
            SELECT 102,'Ana','Martínez','ana.martinez@example.com','+525557654321'
            WHERE NOT EXISTS (SELECT 1 FROM Pacientes WHERE Id = 102);

            INSERT INTO Pacientes (Id,Nombre,Apellido,Email,Telefono)
            SELECT 103,'Luis','Rodríguez','luis.rodriguez@example.com','+525559876543'
            WHERE NOT EXISTS (SELECT 1 FROM Pacientes WHERE Id = 103);

            INSERT INTO Pacientes (Id,Nombre,Apellido,Email,Telefono)
            SELECT 104,'María','López','maria.lopez@example.com','+525553456789'
            WHERE NOT EXISTS (SELECT 1 FROM Pacientes WHERE Id = 104);

            INSERT INTO Pacientes (Id,Nombre,Apellido,Email,Telefono)
            SELECT 105,'Jorge','Sánchez','jorge.sanchez@example.com','+525552345678'
            WHERE NOT EXISTS (SELECT 1 FROM Pacientes WHERE Id = 105);
            ";
            cmd.ExecuteNonQuery();
        }

        public List<Paciente> ObtenerTodos()
        {
            using var conn = Conectar();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Pacientes";

            var lista = new List<Paciente>();

            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                lista.Add(new Paciente
                {
                    Id = r.GetInt32(0),
                    Nombre = r.GetString(1),
                    Apellido = r.GetString(2),
                    Email = r.IsDBNull(3) ? "" : r.GetString(3),
                    Telefono = r.IsDBNull(4) ? "" : r.GetString(4)
                });
            }

            return lista;
        }

        public Paciente? ObtenerPorId(int id)
        {
            return ObtenerTodos().FirstOrDefault(x => x.Id == id);
        }
        public void Agregar(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public void Actualizar(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}