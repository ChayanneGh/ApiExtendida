using Microsoft.AspNetCore.Mvc;

namespace ApiExtendida.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class MCDController : ControllerBase
{
    [HttpGet("{dividendo:int}/{divisor:int}")]
    public IActionResult mcd(int dividendo, int divisor)
    {
        while (divisor != 0)
        {
            int residuo = dividendo % divisor;
            dividendo = divisor;
            divisor = residuo;
        }

        return Ok($"El MCD es {dividendo}");
    }
}