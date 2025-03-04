using Dapper;
using Npgsql;
using PruebaTecnica.Modelos;
using System.Data;

namespace PruebaTecnica.Repositorios
{
    public class CuentaRepository
    {
        private readonly string _connectionString;

        public CuentaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("PostgrestConnection");
        }

        private IDbConnection Connection => new NpgsqlConnection(_connectionString);

        // Obtener todas las cuentas
        public async Task<IEnumerable<Cuenta>> ObtenerCuentasAsync()
        {
            using (var db = Connection)
            {
                return await db.QueryAsync<Cuenta>("SELECT * FROM cuentas");
            }
        }

        // Obtener cuenta por ID
        public async Task<Cuenta> ObtenerCuentaPorIdAsync(int id)
        {
            using (var db = Connection)
            {
                return await db.QueryFirstOrDefaultAsync<Cuenta>("SELECT * FROM cuentas WHERE id_cuenta = @IdCuenta", new { IdCuenta = id });
            }
        }

        // Insertar una nueva cuenta
        public async Task<int> InsertarCuentaAsync(Cuenta cuenta)
        {
            using (var db = Connection)
            {
                string sql = @"INSERT INTO cuentas (id_cliente, numerocuenta, saldo, tipocuenta, estadocuenta) 
                           VALUES (@IdCliente, @NumeroCuenta, @Saldo, @TipoCuenta, @EstadoCuenta) 
                           RETURNING id_cuenta;";

                return await db.ExecuteScalarAsync<int>(sql, cuenta);
            }
        }

        // Actualizar cuenta
        public async Task<bool> ActualizarCuentaAsync(Cuenta cuenta)
        {
            using (var db = Connection)
            {
                string sql = @"UPDATE cuentas 
                           SET id_cliente = @IdCliente, numerocuenta = @NumeroCuenta, saldo = @Saldo, 
                               tipocuenta = @TipoCuenta, estadocuenta = @EstadoCuenta 
                           WHERE id_cuenta = @IdCuenta";

                int rowsAffected = await db.ExecuteAsync(sql, cuenta);
                return rowsAffected > 0;
            }
        }

        // Eliminar cuenta por ID
        public async Task<bool> EliminarCuentaAsync(int id)
        {
            using (var db = Connection)
            {
                string sql = "DELETE FROM cuentas WHERE id_cuenta = @IdCuenta";
                int rowsAffected = await db.ExecuteAsync(sql, new { IdCuenta = id });
                return rowsAffected > 0;
            }
        }
    }
}
