using Microsoft.AspNetCore.Mvc;

namespace ApiExtendida.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class MCDController : ControllerBase
{
    [HttpGet("{dividendo:int}/{divisor:int}")]
    //la pai tiene que resivir los paraetros similar a dividendo%=int y divisor%=int por lo que tiene que estar arregado
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