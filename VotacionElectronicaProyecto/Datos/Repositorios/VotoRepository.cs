using Api.Data;
using Datos.Repositorios.IRepositorios;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class VotoRepository : IVotoRepository
    {
        private readonly DataContext _context;

        public VotoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Crear(Voto voto)
        {
            _context.Voto.Add(voto);
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var voto = await _context.Voto.FindAsync(id);
            if (voto != null)
            {
                _context.Voto.Remove(voto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
