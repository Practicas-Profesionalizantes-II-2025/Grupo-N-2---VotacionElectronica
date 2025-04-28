using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using Shared.Dtos.Lista;



namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListaController : ControllerBase
    {
        private readonly DataContext _context;

        public ListaController(DataContext context)
        {
            _context = context;
        }
        // GET: api/Lista
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lista>>> GetLista()
        {
            return await _context.Lista.ToListAsync();
        }
        // GET: api/Lista/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Lista>> GetLista(int id)
        {
            var lista = await _context.Lista.FindAsync(id);

            if (lista == null)
            {
                return NotFound();
            }

            return lista;
        }
        // GET: api/Lista/nombre
        [HttpGet("nombre/{nombre}")]
        public async Task<ActionResult<IEnumerable<Lista>>> GetLista(string nombre)
        {
            var queryable = _context.Lista.AsQueryable().Where(x => x.NombreLista.Contains(nombre));

            var lista = await queryable.ToListAsync();

            if (lista == null || lista.Count == 0)
            {
                return NotFound();
            }

            return lista;
        }
        // PUT: api/Lista/{0}

        [HttpPut("{id}")]
        public async Task<ActionResult<Lista>> PutLista(int id, ModificarDTO lista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingLista = await _context.Lista.FindAsync(id);
            if (existingLista == null)
            {
                return NotFound();
            }
            _context.Entry(existingLista).State = EntityState.Modified;

            existingLista.NombreLista = lista.NombreLista;
            existingLista.DescripcionLista = lista.DescripcionLista;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return existingLista;
        }
        // POST: api/Lista

        [HttpPost]
        public async Task<ActionResult<Lista>> PostLista(CrearDTO lista)
        {
            Lista listaEntity = new Lista();

            try
            {
                listaEntity.NombreLista = lista.NombreLista;
                listaEntity.DescripcionLista = lista.DescripcionLista;
                listaEntity.CantidadIntegrantes = 1;

                _context.Lista.Add(listaEntity);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetLista", new { id = listaEntity.Id }, listaEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        // DELETE: api/Lista/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLista(int id)
        {
            var lista = await _context.Lista.FindAsync(id);
            if (lista == null)
            {
                return NotFound();
            }

            _context.Lista.Remove(lista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListaExists(int id)
        {
            return _context.Lista.Any(e => e.Id == id);
        }
    }
}
