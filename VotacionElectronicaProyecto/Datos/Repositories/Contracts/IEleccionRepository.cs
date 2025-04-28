using Shared.Entities;

namespace Datos.Repositories.Contracts
{
    public interface IEleccionRepository : IRepository<Eleccion>
    {
        Task<List<Eleccion>> GetAll();
    }
}
