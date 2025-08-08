using Api.Data;
using Datos.Repositorios.IRepositorios;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.Resultado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class ResultadoRepository : IResultadoRepository
    {
        private readonly DataContext _context;

        public ResultadoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ResultadoDto>> ObtenerResultadosAgrupados(int eleccionId)
        {
            return await _context.Voto
                .Where(v => v.EleccionId == eleccionId)
                .GroupBy(v => new { v.ListaId, v.Lista.NombreLista })
                .Select(g => new ResultadoDto
                {
                    ListaId = g.Key.ListaId,
                    NombreLista = g.Key.NombreLista,
                    TotalVotos = g.Count()
                })
                .ToListAsync();
        }

    }
}
