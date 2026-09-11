using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Dapper;

namespace ApiExtendida.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendedoresController : ControllerBase
{
    private readonly string _connectionString;

    public VendedoresController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("AzureConnection")!;
    }

    // ENDPOINT: GET /api/vendedores
    [HttpGet]
    public async Task<IActionResult> ObtenerVendedores()
    {
        // Ajustado perfectamente a la estructura que creamos en Azure SQL
        string sqlQuery = @"SELECT Id, Nombre, Apellido, Telefono, Reputacion, 
                                [fecha de inicio] AS FechaInicio, ID_Direccion 
                                FROM Vendedores";

        using (var connection = new SqlConnection(_connectionString))
        {
            try
            {
                // Dapper mapea directamente a la clase interna Vendedor
                var vendedores = await connection.QueryAsync<Vendedor>(sqlQuery);

                return Ok(vendedores);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener datos desde la DB: {ex.Message}");
            }
        }
    }
}

public class Vendedor
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Reputacion { get; set; } = string.Empty;
    public DateTime FechaInicio { get; set; }
    public int ID_Direccion { get; set; }
}