using Shared.Entities;
namespace Datos.Repositories.Contracts
{
    public interface IResultadoRepository : IRepository<Resultado>
    {
        Task<List<Resultado>> GetAll();
    }
}
