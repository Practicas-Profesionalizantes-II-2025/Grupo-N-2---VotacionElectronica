using Datos.Context;
using Datos.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositories
{
    public class PersonaRepository : Repository<Persona>, IPersonaRepository
    {
        public PersonaRepository(VotacionContext context) : base(context) { }
        public async Task<List<Persona>> GetAll()
        {
            try
            {
                return await _context.Persona.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    
}
