using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Dapper;
using ApiExtendida.Controllers.Modelos;

namespace ApiExtendida.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstudiantesController : ControllerBase
{
    private readonly Somee_DataService _service;

    public EstudiantesController(Somee_DataService service)
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
