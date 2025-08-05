using Shared.Dtos.Eleccion;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios.IRepositorios
{
    public interface IEleccionRepository
    {
        Task<List<Eleccion>> ObtenerTodas();
        Task<Eleccion> ObtenerPorId(int id);
        Task<List<Eleccion>> ObtenerPorNombre(string nombre);
        Task<List<Eleccion>> FiltrarPorTexto(string texto);
        Task<Eleccion> Crear(Eleccion eleccion);
        Task Actualizar(Eleccion eleccion);
        Task Eliminar(int id);

        Task AsignarLista(AsignarListaDTO dto);
        Task<List<Lista>> ObtenerListasPorEleccion(int eleccionId);
        Task RemoverListaDeEleccion(int eleccionId, int listaId);

        Task AsignarPersona(AsignarPersonaEleccionDTO dto);

    }
}
