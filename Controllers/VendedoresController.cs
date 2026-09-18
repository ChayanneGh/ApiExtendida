using Microsoft.AspNetCore.Mvc;

namespace ApiExtendida.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Recomendado anteponer "api/" por estándar REST
    public class VendedoresController : ControllerBase // 1. Cambiado a ControllerBase
    {
        private readonly Servicios.Azure_DataServices _service;

        public VendedoresController(Servicios.Azure_DataServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sql = "SELECT * FROM Vendedores";
            var Vendedores = await _service.GetAllAsync<Modelos.Vendedor>(sql);
            return Ok(Vendedores); // Devuelve JSON automáticamente
        }
    }
}
