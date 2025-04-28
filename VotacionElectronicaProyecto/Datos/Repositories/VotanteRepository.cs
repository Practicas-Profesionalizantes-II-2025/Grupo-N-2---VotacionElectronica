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
    public class VotanteRepository : Repository<Votante>, IVotanteRepository
    {
        public VotanteRepository(VotacionContext context) : base(context) 
        { 

        }
        public async Task<List<Votante>> GetAll()
        {
            try
            {
                return await _context.Votante.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }    
}
