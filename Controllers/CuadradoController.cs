using Microsoft.AspNetCore.Mvc;

namespace ApiExtendida.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CuadradoController : Controller
    {
        [HttpGet ("{numero:int}")]
        public IActionResult Index(int numero)
        {
            if (numero < 0)
            {
                return BadRequest(new { message = "El número debe ser mayor o igual a cero." });
            }  
            return Ok(new { resultado = numero * numero });
        }
    }
}
