using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using Shared.Dtos.Voto;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VotoController : ControllerBase
    {
        private readonly DataContext _context;

        public VotoController(DataContext context)
        {
            _context = context;
        }

        // POST: api/voto
        [HttpPost]
        public async Task<IActionResult> RegistrarVoto(CrearDTO votoDto)
        {
            var personaEleccion = await _context.PersonaElecciones
                .FirstOrDefaultAsync(pe => pe.EleccionId == votoDto.EleccionId && pe.Autorizada);

            if (personaEleccion == null)
            {
                return BadRequest("La persona no está autorizada o ya ha votado en esta elección.");
            }

            var voto = new Voto
            {
                FechaVoto = DateTime.Now,
                EleccionId = votoDto.EleccionId,
                ListaId = votoDto.ListaId
            };

            _context.Voto.Add(voto);
            personaEleccion.Autorizada = false; // Desautorizar para esa elección
            _context.PersonaElecciones.Update(personaEleccion);

            await _context.SaveChangesAsync();

            return Ok("Voto registrado exitosamente.");
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Borrar(int id)
        {
            var votoExistente = await _context.Voto.FindAsync(id);
            if (votoExistente == null)
                return NotFound("Voto no encontrado.");

            _context.Voto.Remove(votoExistente); // Eliminar el voto
            await _context.SaveChangesAsync(); // Guardar cambios

            return NoContent();
        }
    }
}

