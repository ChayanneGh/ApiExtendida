using Microsoft.Data.SqlClient;
using Dapper;
public class Azure_DataService
{
    private readonly string _connectionString;

    public Azure_DataService(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("AzureConnection")!;
    }

    public async Task<IEnumerable<T>> GetAllAsync<T>(string sql)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<T>(sql);
    }
}