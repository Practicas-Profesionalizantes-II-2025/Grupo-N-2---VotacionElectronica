using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using Shared.Dtos.Eleccion;
using Microsoft.Data.SqlClient;




namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EleccionController : ControllerBase
    {
        private readonly DataContext _context;

        public EleccionController(DataContext context)
        {
            _context = context;
        }
        // GET: api/Eleccion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Eleccion>>> GetEleccion()
        {
            return await _context.Eleccion.ToListAsync();
        }
        // GET: api/Eleccion/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Eleccion>> GetEleccion(int id)
        {
            var eleccion = await _context.Eleccion.FindAsync(id);

            if (eleccion == null)
            {
                return NotFound();
            }

            return eleccion;
        }
        // GET: api/Eleccion/nombre
        [HttpGet("nombre/{nombre}")]
        public async Task<ActionResult<IEnumerable<Eleccion>>> GetEleccion(string nombre)
        {
            var queryable = _context.Eleccion.AsQueryable().Where(x => x.NombreEleccion.Contains(nombre));

            var eleccion = await queryable.ToListAsync();

            if (eleccion == null || eleccion.Count == 0)
            {
                return NotFound();
            }

            return eleccion;
        }
        // PUT: api/Eleccion/5

        [HttpPut("{id}")]
        public async Task<ActionResult<Eleccion>> PutEleccion(int id, ModificarDTO eleccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingEleccion = await _context.Eleccion.FindAsync(id);
            if (existingEleccion == null)
            {
                return NotFound();
            }
            _context.Entry(existingEleccion).State = EntityState.Modified;

            existingEleccion.NombreEleccion = eleccion.NombreEleccion;
            existingEleccion.DescripcionEleccion = eleccion.DescripcionEleccion;
            existingEleccion.CantidadListas = eleccion.CantidadListas;
            existingEleccion.FechaFinEleccion = eleccion.FechaFinEleccion;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EleccionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return existingEleccion;
        }
        // POST: api/Eleccion

        [HttpPost]
        public async Task<ActionResult<Eleccion>> PostEleccion(CrearDTO eleccion)
        {
            Eleccion eleccionEntity = new Eleccion();
            try
            {
                eleccionEntity.NombreEleccion = eleccion.NombreEleccion;
                eleccionEntity.DescripcionEleccion = eleccion.DescripcionEleccion;
                eleccionEntity.CantidadListas = eleccion.CantidadListas;
                eleccionEntity.FechaInicioEleccion = eleccion.FechaInicioEleccion;
                eleccionEntity.FechaFinEleccion = eleccion.FechaFinEleccion;
                eleccionEntity.CreatedDate = eleccion.CreatedDate;


                _context.Eleccion.Add(eleccionEntity);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEleccion", new { id = eleccionEntity.Id }, eleccionEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // DELETE: api/Eleccion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEleccion(int id)
        {
            var eleccion = await _context.Eleccion.FindAsync(id);
            if (eleccion == null)
            {
                return NotFound();
            }

            _context.Eleccion.Remove(eleccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Eleccion/AsignarLista
        [HttpPost("AsignarLista")]
        public async Task<ActionResult> AsignarLista(AsignarListaDTO asignarListaDto)
        {
            try
            {
                var eleccionLista = new EleccionLista
                {
                    IdEleccion = asignarListaDto.EleccionId,
                    IdLista = asignarListaDto.ListaId,
                    DescripcionEleccionLista = asignarListaDto.Descripcion // Asegúrate de que el DTO incluya este campo.
                };

                _context.EleccionListas.Add(eleccionLista);
                await _context.SaveChangesAsync();

                return Ok("Lista asignada exitosamente a la elección.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error inesperado al asignar la lista: {ex.Message}");
            }
        }


            // GET: api/Eleccion/{id}/Listas
            [HttpGet("{id}/Listas")]
            public async Task<ActionResult<IEnumerable<Lista>>> GetListasByEleccion(int id)
        {   
            var eleccion = await _context.Eleccion
                .Include(e => e.Listas) // Asegúrate de que la relación está configurada correctamente
                .FirstOrDefaultAsync(e => e.Id == id);

            if (eleccion == null)
            {
                return NotFound();
            }

            return Ok(eleccion.Listas);
        }


        // DELETE: api/Eleccion/{id}/Listas/{listaId}
        [HttpDelete("{id}/Listas/{listaId}")]
        public async Task<IActionResult> RemoveListaFromEleccion(int id, int listaId)
        {
            var eleccion = await _context.Eleccion
                .Include(e => e.Listas)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (eleccion == null)
            {
                return NotFound("Elección no encontrada");
            }

            var lista = eleccion.Listas.FirstOrDefault(l => l.Id == listaId);
            if (lista == null)
            {
                return NotFound("Lista no asignada a esta elección");
            }

            eleccion.Listas.Remove(lista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Eleccion/AsignarPersona
        [HttpPost("AsignarPersona")]
        public async Task<ActionResult> AsignarPersona(AsignarPersonaEleccionDTO asignarPersonaDto)
        {
            try
            {
                var personaEleccion = new PersonaEleccion
                {
                    PersonaId = asignarPersonaDto.PersonaId,
                    EleccionId = asignarPersonaDto.EleccionId,
                    Autorizada = true // Asignar como verdadera explícitamente
                };

                _context.PersonaElecciones.Add(personaEleccion);
                await _context.SaveChangesAsync();

                return Ok("Persona asignada a la elección exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error inesperado al asignar la persona: {ex.Message}");
            }
        }

        
        



        private bool EleccionExists(int id)
        {
            return _context.Eleccion.Any(e => e.Id == id);
        }
    }
}
