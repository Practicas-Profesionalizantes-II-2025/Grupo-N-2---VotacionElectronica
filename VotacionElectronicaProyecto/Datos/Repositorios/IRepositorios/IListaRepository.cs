using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios.IRepositorios
{
    public interface IListaRepository
    {
        Task<List<Lista>> ObtenerTodos();
        Task<Lista> ObtenerPorId(int id);
        Task<List<Lista>> BuscarPorNombre(string nombre);
        Task<Lista> Crear(Lista lista);
        Task Actualizar(Lista lista);
        Task Eliminar(int id);
        Task<List<Lista>> ObtenerListasNoAsignadas(int eleccionId, int solicitanteId);


    }
}
