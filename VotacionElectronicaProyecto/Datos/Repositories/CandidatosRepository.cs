using Datos.Context;
using Datos.Repositories.Contracts;
using Shared.Entities;
using Datos.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Datos.Repositories
{
    public class CandidatosRepository : Repository<Candidatos>, ICandidatosRepository
    {
        public CandidatosRepository(VotacionContext context) : base(context)
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

        Task<List<Candidatos>> ICandidatosRepository.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

