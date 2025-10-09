using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio.Logica.ILogica;
using Shared.Dtos.Persona;
using Shared.Entities;
using Shared.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaLogic _logic;

        public PersonaController(IPersonaLogic logic)
        {
            _logic = logic;
        }

        [HttpGet("porUsuario/{solicitanteId}")]
        public async Task<IActionResult> ObtenerTodas(int solicitanteId)
        {
            var personas = await _logic.ObtenerTodas(solicitanteId);
            return Ok(personas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var persona = await _logic.ObtenerPorId(id);
            if (persona == null) return NotFound();
            return Ok(persona);
        }

        [HttpGet("buscarPorNombre/{nombre}")]
        public async Task<IActionResult> ObtenerPorNombre(string nombre)
        {
            var personas = await _logic.ObtenerPorNombre(nombre);
            return Ok(personas);
        }

        [HttpGet("dni/{dni}")]
        public async Task<IActionResult> ObtenerPorDNI(string dni)
        {
            var persona = await _logic.ObtenerPorDNI(dni);
            if (persona == null) return NotFound();
            return Ok(persona);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(CrearDTO dto, int id)
        {
            try
            {
                await _logic.Crear(dto, id);
                return Ok("Persona creada correctamente");
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
        public async Task<IActionResult> Actualizar(int id, ModificarDTO dto, int solicitanteId)
        {
            await _logic.Actualizar(id, dto, dto.SolicitanteId);
            return Ok("Persona actualizada correctamente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id, int solicitanteId)
        {
            await _logic.Eliminar(id, solicitanteId);
            return NoContent();
        }

        [HttpPost("autenticar")]
        public async Task<IActionResult> Autenticar([FromBody] LoginDto dto)
        {
            try
            {
                var persona = await _logic.Autenticar(dto.Dni, dto.Password);
                return Ok(persona);
            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }


        [HttpGet("eleccionesAutorizadas/{dni}")]
        public async Task<IActionResult> ObtenerEleccionesAutorizadas(string dni)
        {
            var elecciones = await _logic.ObtenerEleccionesAutorizadas(dni);
            return Ok(elecciones);
        }

        [HttpGet("eleccionesAsignadas/{dni}")]
        public async Task<IActionResult> ObtenerAsignadas(string dni)
        {
            var personas = await _logic.ObtenerEleccionesAsignadas(dni);
            return Ok(personas);
        }

        [HttpGet("noAsignadas/{eleccionId:int}/{solicitanteId:int}")]
        public async Task<IActionResult> ObtenerPersonasNoAsignadas(int eleccionId, int solicitanteId)
        {
            var personas = await _logic.ObtenerPersonasNoAsignadas(eleccionId, solicitanteId);
            return Ok(personas);
        }


    }
}
