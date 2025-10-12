using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using Shared.Dtos.Lista;
using Negocio.Logica.ILogica;



namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListaController : ControllerBase
    {
        private readonly IListaLogic _logica;

        public ListaController(IListaLogic logica)
        {
            _logica = logica;
        }

        [HttpGet("porUsuario/{solicitanteId:int}")]
        public async Task<ActionResult<IEnumerable<VerDTO>>> GetListas(int solicitanteId)
        {
            return await _logica.ObtenerListas(solicitanteId);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<VerDTO>> GetLista(int id)
        {
            var lista = await _logica.ObtenerListasPorId(id);
            if (lista == null) return NotFound();
            return lista;
        }

        [HttpGet("nombre/{nombre}")]
        public async Task<ActionResult<IEnumerable<VerDTO>>> BuscarPorNombre(string nombre)
        {
            var lista = await _logica.ObtenerListasPorNombre(nombre);
            if (lista == null || !lista.Any()) return NotFound();
            return Ok(lista);
        }

        [HttpPost("{solicitanteId:int}")]
        public async Task<ActionResult> Crear(int solicitanteId, [FromBody] CrearDTO dto)
        {
            try
            {
                await _logica.CrearLista(dto, solicitanteId);
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
                await _logica.ActualizarLista(id, dto);
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
            await _logica.EliminarLista(id);
            return NoContent();
        }

        [HttpGet("noAsignadas/{eleccionId:int}/{solicitanteId:int}")]
        public async Task<IActionResult> ObtenerListasNoAsignadas(int eleccionId, int solicitanteId)
        {
            var listas = await _logica.ObtenerListasNoAsignadas(eleccionId, solicitanteId);
            return Ok(listas);
        }

    }
}

