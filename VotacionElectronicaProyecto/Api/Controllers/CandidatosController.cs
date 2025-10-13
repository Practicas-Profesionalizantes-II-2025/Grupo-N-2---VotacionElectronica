using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using Shared.Dtos.Candidatos;
using Negocio.Logica.ILogica;


namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatosController : ControllerBase
    {
        private readonly ICandidatoLogic _logica;

        public CandidatosController(ICandidatoLogic logica)
        {
            _logica = logica;
        }

        [HttpGet("porUsuario/{solicitanteId:int}")]
        public async Task<ActionResult<IEnumerable<VerDTO>>> ObtenerCandidatosPorUsuario(int solicitanteId)
        {
            return await _logica.ObtenerCandidatos(solicitanteId);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<VerDTO>> GetCandidato(int id)
        {
            var candidato = await _logica.ObtenerCandidatoPorId(id);
            if (candidato == null) return NotFound();
            return candidato;
        }

        [HttpGet("nombre/{nombre}")]
        public async Task<ActionResult<IEnumerable<VerDTO>>> BuscarPorNombre(string nombre)
        {
            var lista = await _logica.ObtenerCandidatosPorNombre(nombre);
            if (lista == null || !lista.Any()) return NotFound();
            return Ok(lista);
        }

        [HttpPost("{solicitanteId:int}")]
        public async Task<ActionResult> CrearCandidato(int solicitanteId, [FromBody] CrearDTO dto)
        {
            try
            {
                await _logica.CrearCandidato(dto, solicitanteId);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error inesperado: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Actualizar(int id, ModificarDTO dto)
        {
            try
            {
                await _logica.ActualizarCandidato(id, dto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error inesperado: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            await _logica.EliminarCandidato(id);
            return NoContent();
        }

        [HttpGet("PorLista/{listaId}")]
        public async Task<IActionResult> ObtenerPorLista(int listaId)
        {
            var candidatos = await _logica.ObtenerPorLista(listaId);
            return Ok(candidatos);
        }
    }
}
