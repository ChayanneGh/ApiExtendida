using Microsoft.AspNetCore.Mvc;

namespace ApiExtendida.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class MCDController : Controller
    {
        [HttpGet("{dividendo:int}/{divisor:int}")]
        public IActionResult Index(int dividendo, int divisor)
        {
            while (divisor != 0)
            {
                int residuo = dividendo % divisor;
                dividendo = divisor;
                divisor = residuo;
            }

            return Ok(new { resultado = dividendo });
        }
    }
}
