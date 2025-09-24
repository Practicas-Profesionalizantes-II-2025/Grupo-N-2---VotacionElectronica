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
            return await _context.EleccionListas
                .Where(el => el.IdEleccion == eleccionId)
                .Select(el => new ResultadoDto
                {
                    ListaId = el.IdLista,
                    NombreLista = el.Lista.NombreLista,
                    TotalVotos = _context.Voto
                        .Count(v => v.EleccionId == eleccionId && v.ListaId == el.IdLista)
                })
                .ToListAsync();
        }


    }
}
