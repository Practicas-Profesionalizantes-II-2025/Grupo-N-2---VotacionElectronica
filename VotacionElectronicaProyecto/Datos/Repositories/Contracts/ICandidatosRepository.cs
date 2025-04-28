using Shared.Entities;

namespace Datos.Repositories.Contracts
{
    public interface ICandidatosRepository : IRepository<Candidatos>
    {
        Task<List<Candidatos>> GetAll();
    }
}
