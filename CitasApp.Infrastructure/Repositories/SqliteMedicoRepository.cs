using CitasApp.Domain.Interfaces;
using CitasApp.Domain.Models;
using Microsoft.Data.Sqlite;

namespace CitasApp.Infrastructure.Repositories
{
    public class SqliteMedicoRepository : IMedicoRepository
    {
        private readonly string _connectionString;

        public SqliteMedicoRepository(string dbPath)
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

        // ─────────────────────────────────────────────
        // CREAR TABLA
        // ─────────────────────────────────────────────
        private void Inicializar()
        {
            using var conn = Conectar();
            var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Medicos (
                    Id INTEGER PRIMARY KEY,
                    Nombre TEXT NOT NULL,
                    Apellido TEXT NOT NULL,
                    Especialidad TEXT,
                    NumeroLicencia TEXT
                );
            ";

            cmd.ExecuteNonQuery();
        }

        // ─────────────────────────────────────────────
        // SEED SEGURO (NO DUPLICA DATOS)
        // ─────────────────────────────────────────────
        private void Seed()
        {
            using var conn = Conectar();

            var check = conn.CreateCommand();
            check.CommandText = "SELECT COUNT(*) FROM Medicos";

            long count = (long)check.ExecuteScalar();

            if (count > 0)
                return;

            var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                INSERT INTO Medicos VALUES (1,'Juan','Perez','Cardiología','LIC-1001');
                INSERT INTO Medicos VALUES (2,'Ana','Garcia','Pediatría','LIC-1002');
                INSERT INTO Medicos VALUES (3,'Carlos','Lopez','Dermatología','LIC-1003');
                INSERT INTO Medicos VALUES (4,'María','Hernandez','Ginecología','LIC-1004');
                INSERT INTO Medicos VALUES (5,'Luis','Martinez','Neurología','LIC-1005');
                INSERT INTO Medicos VALUES (6,'Sofia','Ramirez','Oncología','LIC-1006');
                INSERT INTO Medicos VALUES (7,'Diego','Torres','Traumatología','LIC-1007');
                INSERT INTO Medicos VALUES (8,'Laura','Flores','Medicina General','LIC-1008');
                INSERT INTO Medicos VALUES (9,'Jorge','Castillo','Oftalmología','LIC-1009');
                INSERT INTO Medicos VALUES (10,'Patricia','Mendoza','Psiquiatría','LIC-1010');
            ";

            cmd.ExecuteNonQuery();
        }

        // ─────────────────────────────────────────────
        // READ
        // ─────────────────────────────────────────────
        public List<Medico> ObtenerTodos()
        {
            using var conn = Conectar();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Medicos";

            var lista = new List<Medico>();

            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                lista.Add(new Medico
                {
                    Id = r.GetInt32(0),
                    Nombre = r.GetString(1),
                    Apellido = r.GetString(2),
                    Especialidad = r.IsDBNull(3) ? "" : r.GetString(3),
                    NumeroLicencia = r.IsDBNull(4) ? "" : r.GetString(4)
                });
            }

            return lista;
        }

        public Medico? ObtenerPorId(int id)
        {
            return ObtenerTodos().FirstOrDefault(x => x.Id == id);
        }

        // ─────────────────────────────────────────────
        // CREATE
        // ─────────────────────────────────────────────
        public void Agregar(Medico medico)
        {
            using var conn = Conectar();
            var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                INSERT INTO Medicos (Nombre, Apellido, Especialidad, NumeroLicencia)
                VALUES ($nombre, $apellido, $especialidad, $licencia);
            ";

            cmd.Parameters.AddWithValue("$nombre", medico.Nombre);
            cmd.Parameters.AddWithValue("$apellido", medico.Apellido);
            cmd.Parameters.AddWithValue("$especialidad", medico.Especialidad);
            cmd.Parameters.AddWithValue("$licencia", medico.NumeroLicencia);

            cmd.ExecuteNonQuery();
        }

        // ─────────────────────────────────────────────
        // UPDATE
        // ─────────────────────────────────────────────
        public void Actualizar(Medico medico)
        {
            using var conn = Conectar();
            var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                UPDATE Medicos
                SET Nombre = $nombre,
                    Apellido = $apellido,
                    Especialidad = $especialidad,
                    NumeroLicencia = $licencia
                WHERE Id = $id;
            ";

            cmd.Parameters.AddWithValue("$id", medico.Id);
            cmd.Parameters.AddWithValue("$nombre", medico.Nombre);
            cmd.Parameters.AddWithValue("$apellido", medico.Apellido);
            cmd.Parameters.AddWithValue("$especialidad", medico.Especialidad);
            cmd.Parameters.AddWithValue("$licencia", medico.NumeroLicencia);

            cmd.ExecuteNonQuery();
        }

        // ─────────────────────────────────────────────
        // DELETE
        // ─────────────────────────────────────────────
        public void Eliminar(int id)
        {
            using var conn = Conectar();
            var cmd = conn.CreateCommand();

            cmd.CommandText = "DELETE FROM Medicos WHERE Id = $id";
            cmd.Parameters.AddWithValue("$id", id);

            cmd.ExecuteNonQuery();
        }
    }
}