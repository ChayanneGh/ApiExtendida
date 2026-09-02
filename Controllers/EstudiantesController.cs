using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Dapper;

[ApiController]
[Route("api/[controller]")]
public class EstudiantesController : ControllerBase
{
    private readonly DataService _service;

    public EstudiantesController(DataService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var sql = "SELECT * FROM Estudiantes";
        var estudiantes = await _service.GetAllAsync<Estudiante>(sql);
        return Ok(estudiantes); // Devuelve JSON
    }
}

public class DataService
{
    private readonly string _connectionString;

    public DataService(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<T>> GetAllAsync<T>(string sql)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<T>(sql);
    }
}


public class Estudiante
{
    public int ID_Estudiante { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }
    public int ID_Direccion { get; set; }
}