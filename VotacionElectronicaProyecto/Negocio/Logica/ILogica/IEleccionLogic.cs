using Shared.Dtos.Eleccion;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Logica.ILogica
{
    public interface IEleccionLogic
    {
        Task<List<VerDTO>> ObtenerTodas();
        Task<VerDTO> ObtenerPorId(int id);
        Task<List<VerDTO>> ObtenerPorNombre(string nombre);
        Task<List<VerDTO>> FiltrarPorTexto(string textoBusqueda);
        Task Crear(CrearDTO dto);
        Task Actualizar(int id, ModificarDTO dto);
        Task Eliminar(int id);

        Task AsignarLista(AsignarListaDTO dto);
        Task<List<Lista>> ObtenerListasPorEleccion(int id);
        Task RemoverListaDeEleccion(int eleccionId, int listaId);

        Task AsignarPersona(AsignarPersonaEleccionDTO dto);
    }
}
