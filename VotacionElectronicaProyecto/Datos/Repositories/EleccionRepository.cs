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
    public class EleccionRepository : Repository<Eleccion>, IEleccionRepository
    {
        public EleccionRepository(VotacionContext context) : base(context) { }
        public async Task<List<Eleccion>> GetAll()
        {
            try
            {
                return await _context.Eleccion.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
