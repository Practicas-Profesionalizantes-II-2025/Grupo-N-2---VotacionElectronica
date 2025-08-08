using Shared.Dtos.Resultado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios.IRepositorios
{
    public interface IResultadoRepository
    {
        Task<List<ResultadoDto>> ObtenerResultadosAgrupados(int eleccionId);

    }
}
