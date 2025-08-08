using Datos.Repositorios.IRepositorios;
using Negocio.Logica.ILogica;
using Shared.Dtos.Resultado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Logica
{
    public class ResultadoLogic : IResultadoLogic
    {
        private readonly IResultadoRepository _repositorio;

        public ResultadoLogic(IResultadoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<ResultadoDto>> ObtenerResultados(int eleccionId)
        {
            return await _repositorio.ObtenerResultadosAgrupados(eleccionId);
        }

    }
}
