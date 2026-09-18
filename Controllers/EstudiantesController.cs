using Microsoft.AspNetCore.Mvc;

namespace ApiExtendida.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Recomendado anteponer "api/" por estándar REST
    public class EstudiantesController : ControllerBase // 1. Cambiado a ControllerBase
    {
        private readonly Servicios.Somee_DataServices _service;

        public EstudiantesController(Servicios.Somee_DataServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sql = "SELECT * FROM Estudiantes";
            var estudiantes = await _service.GetAllAsync<Modelos.Estudiante>(sql);
            return Ok(estudiantes); // Devuelve JSON automáticamente
        }
    }
}
