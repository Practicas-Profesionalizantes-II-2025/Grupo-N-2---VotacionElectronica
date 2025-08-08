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

        [HttpGet]
        public async Task<IActionResult> ObtenerTodas()
        {
            var personas = await _logic.ObtenerTodas();
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
        public async Task<IActionResult> Crear(CrearDTO dto)
        {
            await _logic.Crear(dto);
            return Ok("Persona creada correctamente");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, ModificarDTO dto)
        {
            await _logic.Actualizar(id, dto);
            return Ok("Persona actualizada correctamente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _logic.Eliminar(id);
            return NoContent();
        }

        [HttpGet("autenticar/{contrasenia}")]
        public async Task<IActionResult> Autenticar(string contrasenia)
        {
            var persona = await _logic.AutenticarPorContrasenia(contrasenia);
            if (persona == null) return Unauthorized();
            return Ok(persona);
        }

        [HttpGet("eleccionesAutorizadas/{dni}")]
        public async Task<IActionResult> ObtenerEleccionesAutorizadas(string dni)
        {
            var elecciones = await _logic.ObtenerEleccionesAutorizadas(dni);
            return Ok(elecciones);
        }



    }
}
