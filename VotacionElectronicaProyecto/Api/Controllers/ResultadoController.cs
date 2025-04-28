using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using Shared.Dtos.Resultado; // Importa tu DTO
using Api.Data;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/resultado")]
    public class ResultadoController : ControllerBase
    {
        private readonly DataContext _context;

        public ResultadoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/resultado/{eleccionId}
        [HttpGet("{eleccionId}")]
        public async Task<IActionResult> ObtenerResultados(int eleccionId)
        {
            if (eleccionId <= 0)
            {
                return BadRequest("El ID de la elección debe ser un número positivo.");
            }

            try
            {
                var resultados = await _context.Voto
                    .Where(v => v.EleccionId == eleccionId)
                    .GroupBy(v => v.ListaId)
                    .Select(g => new ResultadoDto // Usar un DTO para la respuesta
                    {
                        ListaId = g.Key,
                        TotalVotos = g.Count()
                    })
                    .ToListAsync();

                if (resultados == null || !resultados.Any())
                {
                    return NotFound("No se encontraron resultados para la elección especificada.");
                }

                return Ok(resultados);
            }
            catch (Exception ex)
            {
                // Loguear el error (opcional)
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}