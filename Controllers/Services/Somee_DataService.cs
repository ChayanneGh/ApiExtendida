using Microsoft.Data.SqlClient;
using Dapper;
public class Somee_DataService
{
    private readonly string _connectionString;

    public Somee_DataService(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("SomeeConnection")!;
    }

    public async Task<IEnumerable<T>> GetAllAsync<T>(string sql)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<T>(sql);
    }
}