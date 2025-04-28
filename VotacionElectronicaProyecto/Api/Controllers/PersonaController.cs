using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using Shared.Dtos.Persona;
using Shared.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonaController(DataContext context)
        {
            _context = context;
        }
        // GET: api/Persona
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersona()
        {
            return await _context.Persona.ToListAsync();
        }
        // GET: api/Persona/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            var persona = await _context.Persona.FindAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }
        // GET: api/Persona/nombre
        [HttpGet("nombre/{nombre}")]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersona(string nombre)
        {
            var queryable = _context.Persona.AsQueryable().Where(x => x.NombrePersona.Contains(nombre));

            var persona = await queryable.ToListAsync();

            if (persona == null || persona.Count == 0)
            {
                return NotFound();
            }

            return persona;
        }

        // GET: api/Persona/dni/{dni}
        [HttpGet("dni/{dni}")]
        public async Task<ActionResult<Persona>> GetPersonaDNI(string dni)
        {
            var persona = await _context.Persona
                .FirstOrDefaultAsync(x => x.NroIdentificacionPersona == dni); // Suponiendo que tienes una propiedad "Dni" en tu entidad Persona

            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }

        // PUT: api/Persona/5

        [HttpPut("{id}")]
        public async Task<ActionResult<Persona>> PutPersona(int id, ModificarDTO persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingPersona = await _context.Persona.FindAsync(id);
            if (existingPersona == null)
            {
                return NotFound();
            }
            _context.Entry(existingPersona).State = EntityState.Modified;

            existingPersona.NombrePersona = persona.NombrePersona;
            existingPersona.ApellidoPersona = persona.ApellidoPersona;
            existingPersona.ContraseniaPersona = persona.ContraseniaPersona;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return existingPersona;
        }
        // POST: api/Persona
        
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(CrearDTO persona)
        {
            Persona personaEntity = new Persona();

            try
            {
                personaEntity.NombrePersona = persona.NombrePersona;
                personaEntity.ApellidoPersona = persona.ApellidoPersona;
                personaEntity.TipoDocumentoPersona = persona.TipoDocumentoPersona;
                personaEntity.NroIdentificacionPersona = persona.NroIdentificacionPersona;

                var seguridadServicio = new SeguridadServicio();

                // Generar y asignar la contraseña
                personaEntity.ContraseniaPersona = seguridadServicio.CrearContrasenia(persona.NroIdentificacionPersona);



                _context.Persona.Add(personaEntity);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPersona", new { id = personaEntity.Id }, personaEntity);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        // DELETE: api/Persona/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var persona = await _context.Persona.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            _context.Persona.Remove(persona);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonaExists(int id)
        {
            return _context.Persona.Any(e => e.Id == id);
        }

        // GET: api/Persona/autenticar/{password}
        [HttpGet("autenticar/{password}")]
        public async Task<ActionResult<Persona>> AutenticarPorContraseña(string password)
        {
            var persona = await _context.Persona.FirstOrDefaultAsync(p => p.ContraseniaPersona == password);

            if (persona == null)
            {
                return NotFound(); 
            }

            return persona;
        }

        // GET: api/Persona/{dni}/EleccionesAutorizadas
        [HttpGet("{dni}/EleccionesAutorizadas")]
        public async Task<ActionResult<IEnumerable<Eleccion>>> GetEleccionesAutorizadas(string dni)
        {
            var elecciones = await _context.PersonaElecciones
                .Where(pe => pe.Persona.NroIdentificacionPersona == dni && pe.Autorizada)
                .Select(pe => pe.Eleccion)
                .ToListAsync();

            if (elecciones == null || elecciones.Count == 0)
            {
                return NotFound();
            }

            return Ok(elecciones);
        }


    }
}
