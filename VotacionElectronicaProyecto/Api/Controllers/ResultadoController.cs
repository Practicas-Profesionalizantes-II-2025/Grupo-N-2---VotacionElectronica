using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio.Logica.ILogica;
using Shared.Dtos.Resultado; // Importa tu DTO
using Shared.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/resultado")]
    public class ResultadoController : ControllerBase
    {
        private readonly IResultadoLogic _logica;

        public ResultadoController(IResultadoLogic logica)
        {
            _logica = logica;
        }

        [HttpGet("{eleccionId:int}")]
        public async Task<IActionResult> ObtenerResultados(int eleccionId)
        {
            if (eleccionId <= 0)
                return BadRequest("El ID de la elección debe ser un número positivo.");

            var resultados = await _logica.ObtenerResultados(eleccionId);

            if (resultados == null || !resultados.Any())
                return NotFound("No se encontraron resultados para la elección especificada.");

            return Ok(resultados);
        }

    }
}