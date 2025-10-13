using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios.IRepositorios
{
    public interface ICandidatoRepository
    {
        Task<List<Candidatos>> ObtenerTodos();
        Task<Candidatos> ObtenerPorId(int id);
        Task<List<Candidatos>> BuscarPorNombre(string nombre);
        Task<Candidatos> Crear(Candidatos candidato);
        Task Actualizar(Candidatos candidato);
        Task Eliminar(int id);
        Task<List<Candidatos>> ObtenerPorLista(int listaId);


    }
}
