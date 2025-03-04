using System.Data;
using Dapper;
using PruebaTecnica.Models;

namespace PruebaTecnica.Repositorys
{
    public class ClienteRepository
    {
        private readonly string _connectionString;

        public ClienteRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SQLServerConnection");
        }

        private IDbConnection Connection => new Microsoft.Data.SqlClient.SqlConnection(_connectionString);

        // Obtener todos los clientes
        public async Task<IEnumerable<Cliente>> ObtenerClientesAsync()
        {
            using (var db = Connection)
            {
                return await db.QueryAsync<Cliente>("SELECT * FROM Clientes");
            }
        }

        // Obtener cliente por ID
        public async Task<Cliente> ObtenerClientePorIdAsync(int id)
        {
            using (var db = Connection)
            {
                return await db.QueryFirstOrDefaultAsync<Cliente>(
                    "SELECT * FROM Clientes WHERE ID_Cliente = @IdCliente",
                    new { IdCliente = id });
            }
        }

        // Insertar un nuevo cliente
        public async Task<int> InsertarClienteAsync(Cliente cliente)
        {
            using (var db = Connection)
            {
                string sql = @"INSERT INTO Clientes (Nombre, Apellido, DNI, Direccion, Telefono, ID_Estado) 
                           VALUES (@Nombre, @Apellido, @DNI, @Direccion, @Telefono, @IdEstado); 
                           SELECT SCOPE_IDENTITY();";

                return await db.ExecuteScalarAsync<int>(sql, cliente);
            }
        }

        // Actualizar cliente
        public async Task<bool> ActualizarClienteAsync(Cliente cliente)
        {
            using (var db = Connection)
            {
                string sql = @"UPDATE Clientes 
                           SET Nombre = @Nombre, Apellido = @Apellido, DNI = @DNI, 
                               Direccion = @Direccion, Telefono = @Telefono, ID_Estado = @IdEstado
                           WHERE ID_Cliente = @IdCliente";

                int rowsAffected = await db.ExecuteAsync(sql, cliente);
                return rowsAffected > 0;
            }
        }

        // Eliminar cliente por ID
        public async Task<bool> EliminarClienteAsync(int id)
        {
            using (var db = Connection)
            {
                string sql = "DELETE FROM Clientes WHERE ID_Cliente = @IdCliente";
                int rowsAffected = await db.ExecuteAsync(sql, new { IdCliente = id });
                return rowsAffected > 0;
            }
        }
    }
    public class ClientesRepository
    {
    }
}
