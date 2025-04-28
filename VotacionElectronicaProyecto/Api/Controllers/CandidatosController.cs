using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using Shared.Dtos.Candidatos;


namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatosController : ControllerBase
    {
        private readonly DataContext _context;

        public CandidatosController(DataContext context)
        {
            _context = context;
        }
        // GET: api/Candidatos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidatos>>> GetCandidatos()
        {
            return await _context.Candidatos.ToListAsync();
        }
        // GET: api/Candidatos/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Candidatos>> GetCandidatos(int id)
        {
            var candidatos = await _context.Candidatos.FindAsync(id);

            if (candidatos == null)
            {
                return NotFound();
            }

            return candidatos;
        }
        // GET: api/Candidatos/nombre
        [HttpGet("nombre/{nombre}")]
        public async Task<ActionResult<IEnumerable<Candidatos>>> GetCandidatos(string nombre)
        {
            var queryable = _context.Candidatos.AsQueryable().Where(x => x.NombreCandidato.Contains(nombre));

            var candidatos = await queryable.ToListAsync();

            if (candidatos == null || candidatos.Count == 0)
            {
                return NotFound();
            }

            return candidatos;
        }
        // PUT: api/Candidatos/5
        
        [HttpPut("{id}")]
        public async Task<ActionResult<Candidatos>> PutCandidatos(int id, ModificarDTO candidatos)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCandidatos = await _context.Candidatos.FindAsync(id);
            if (existingCandidatos == null)
            {
                return NotFound();
            }
            _context.Entry(existingCandidatos).State = EntityState.Modified;

            existingCandidatos.NombreCandidato = candidatos.NombreCandidato;
            existingCandidatos.PuestoCandidato = candidatos.PuestoCandidato;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return existingCandidatos;
        }
        // POST: api/Candidatos
        
        [HttpPost]
        public async Task<ActionResult<Candidatos>> PostCandidatos(CrearDTO candidatos)
        {
            Candidatos candidatosEntity = new Candidatos();

            try
            {
                candidatosEntity.PuestoCandidato = candidatos.PuestoCandidato;
                candidatosEntity.NombreCandidato = candidatos.NombreCandidato;
                candidatosEntity.IdLista = candidatos.IdLista;
             

                _context.Candidatos.Add(candidatosEntity);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCandidatos", new { id = candidatosEntity.Id }, candidatosEntity);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
      

            // DELETE: api/Candidatos/5
            [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidatos(int id)
        {
            var candidatos = await _context.Candidatos.FindAsync(id);
            if (candidatos == null)
            {
                return NotFound();
            }

            _context.Candidatos.Remove(candidatos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CandidatosExists(int id)
        {
            return _context.Candidatos.Any(e => e.Id == id);
        }
    }
}
