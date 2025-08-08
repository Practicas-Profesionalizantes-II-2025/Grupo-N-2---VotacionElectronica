using Shared.Dtos.Resultado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Logica.ILogica
{
    public interface IResultadoLogic
    {
        Task<List<ResultadoDto>> ObtenerResultados(int eleccionId);

    }
}
