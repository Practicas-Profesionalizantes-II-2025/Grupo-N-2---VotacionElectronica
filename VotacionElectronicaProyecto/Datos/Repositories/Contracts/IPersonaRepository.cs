using Shared.Entities;

namespace Datos.Repositories.Contracts
{
    public interface IPersonaRepository : IRepository<Persona>
    {
        Task<List<Persona>> GetAll();
    }
}
