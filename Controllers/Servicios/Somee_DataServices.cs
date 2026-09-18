using Microsoft.Data.SqlClient;
using Dapper;

namespace ApiExtendida.Controllers.Servicios
{
    public class Somee_DataServices
    {
        private readonly string _connectionString;

        public Somee_DataServices(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("SomeeConnection")!;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string sql)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<T>(sql);
        }
    }
}
