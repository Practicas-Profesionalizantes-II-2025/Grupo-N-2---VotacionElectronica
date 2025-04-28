using Shared.Entities;

namespace Datos.Repositories.Contracts
{
    public interface IVotanteRepository : IRepository<Votante>
    {
        Task<List<Votante>> GetAll();
    }
}
