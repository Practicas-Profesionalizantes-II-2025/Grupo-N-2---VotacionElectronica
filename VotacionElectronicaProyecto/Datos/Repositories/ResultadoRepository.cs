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
    public class ResultadoRepository : Repository<Resultado>, IResultadoRepository
    {
        public ResultadoRepository(VotacionContext context) : base(context) { }
        public async Task<List<Resultado>> GetAll()
        {
            try
            {
                return await _context.Resultado.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
