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
        Task<List<VerDTO>> ObtenerListas();
        Task<VerDTO> ObtenerListasPorId(int id);
        Task<List<VerDTO>> ObtenerListasPorNombre(string nombre);
        Task CrearLista(CrearDTO dto);
        Task ActualizarLista(int id, ModificarDTO dto);
        Task EliminarLista(int id);
    }
}
