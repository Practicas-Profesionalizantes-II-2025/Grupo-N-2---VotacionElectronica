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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VerDTO>>> GetCandidatos()
        {
            return await _logica.ObtenerCandidatos();
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

        [HttpPost]
        public async Task<ActionResult> Crear(CrearDTO dto)
        {
            await _logica.CrearCandidato(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Actualizar(int id, ModificarDTO dto)
        {
            await _logica.ActualizarCandidato(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            await _logica.EliminarCandidato(id);
            return NoContent();
        }
    }
}
