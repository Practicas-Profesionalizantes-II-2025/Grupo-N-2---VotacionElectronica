using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using Shared.Dtos.Eleccion;
using Microsoft.Data.SqlClient;
using Negocio.Logica;
using Negocio.Logica.ILogica;




namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EleccionController : ControllerBase
    {
        private readonly IEleccionLogic _logica;

        public EleccionController(IEleccionLogic logica)
        {
            _logica = logica;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VerDTO>>> GetEleccion()
        {
            return await _logica.ObtenerTodas();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<VerDTO>> GetEleccion(int id)
        {
            var eleccion = await _logica.ObtenerPorId(id);
            if (eleccion == null) return NotFound();
            return eleccion;
        }

        [HttpGet("nombre/{nombre}")]
        public async Task<ActionResult<IEnumerable<VerDTO>>> GetEleccion(string nombre)
        {
            var lista = await _logica.ObtenerPorNombre(nombre);
            if (!lista.Any()) return NotFound();
            return Ok(lista);
        }

        [HttpGet("filtrar")]
        public async Task<ActionResult<IEnumerable<VerDTO>>> FiltrarPorNombre([FromQuery] string textoBusqueda)
        {
            if (string.IsNullOrWhiteSpace(textoBusqueda))
                return BadRequest("Debe proporcionar un texto de búsqueda.");

            var lista = await _logica.FiltrarPorTexto(textoBusqueda);
            if (!lista.Any()) return NotFound("No se encontraron elecciones.");
            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult> PostEleccion(CrearDTO dto)
        {
            await _logica.Crear(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEleccion(int id, ModificarDTO dto)
        {
            await _logica.Actualizar(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEleccion(int id)
        {
            await _logica.Eliminar(id);
            return NoContent();
        }

        [HttpPost("AsignarLista")]
        public async Task<ActionResult> AsignarLista(AsignarListaDTO dto)
        {
            await _logica.AsignarLista(dto);
            return Ok("Lista asignada exitosamente.");
        }

        [HttpGet("{id}/Listas")]
        public async Task<ActionResult<IEnumerable<Lista>>> GetListasByEleccion(int id)
        {
            var listas = await _logica.ObtenerListasPorEleccion(id);
            if (!listas.Any()) return NotFound();
            return Ok(listas);
        }

        [HttpDelete("{id}/Listas/{listaId}")]
        public async Task<IActionResult> RemoveListaFromEleccion(int id, int listaId)
        {
            await _logica.RemoverListaDeEleccion(id, listaId);
            return NoContent();
        }

        [HttpPost("AsignarPersona")]
        public async Task<ActionResult> AsignarPersona(AsignarPersonaEleccionDTO dto)
        {
            await _logica.AsignarPersona(dto);
            return Ok("Persona asignada correctamente.");
        }
    }
}
