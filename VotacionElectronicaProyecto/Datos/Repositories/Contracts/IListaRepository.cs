using Shared.Entities;

namespace Datos.Repositories.Contracts
{
    public interface IListaRepository : IRepository<Lista>
    {
        Task<List<Lista>> GetAll();
    }
}
