using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Dapper;
using ApiExtendida.Controllers.Modelos;

namespace ApiExtendida.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendedoresController : ControllerBase
{
    private readonly Azure_DataService _service;

    public VendedoresController(Azure_DataService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var sql = "SELECT * FROM Vendedores";
        var vendedores = await _service.GetAllAsync<Vendedor>(sql);
        return Ok(vendedores); // Devuelve JSON
    }
}




