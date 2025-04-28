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
    public class ListaRepository : Repository<Lista>, IListaRepository
    {
        public ListaRepository(VotacionContext context) : base(context) { }

        public async Task<List<Lista>> GetAll()
        {
            try
            {
                return await _context.Lista.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
