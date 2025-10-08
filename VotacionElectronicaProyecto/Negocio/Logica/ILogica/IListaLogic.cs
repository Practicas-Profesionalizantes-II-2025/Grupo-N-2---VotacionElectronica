using Shared.Dtos.Lista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Logica.ILogica
{
    public interface IListaLogic
    {
        Task<List<VerDTO>> ObtenerListas(int Creador);
        Task<VerDTO> ObtenerListasPorId(int id);
        Task<List<VerDTO>> ObtenerListasPorNombre(string nombre);
        Task CrearLista(CrearDTO dto, int Creador);
        Task ActualizarLista(int id, ModificarDTO dto);
        Task EliminarLista(int id);
        Task<List<VerDTO>> ObtenerListasNoAsignadas(int eleccionId, int solicitanteId);


    }
}
