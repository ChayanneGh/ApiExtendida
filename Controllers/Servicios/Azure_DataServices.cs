using Microsoft.Data.SqlClient;
using Dapper;

namespace ApiExtendida.Controllers.Servicios
{
    public class Azure_DataServices
    {
        private readonly string _connectionString;

        public Azure_DataServices(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("AzureConnection")!;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string sql)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<T>(sql);
        }
    }
}
