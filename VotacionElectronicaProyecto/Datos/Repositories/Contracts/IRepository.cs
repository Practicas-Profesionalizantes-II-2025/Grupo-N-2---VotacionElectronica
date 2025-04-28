using System.Linq.Expressions;

namespace Datos.Repositories.Contracts
{
    public interface IRepository<T>
    {
        IEnumerable<T> FindAll();
        Task<IEnumerable<T>> FindAllAsync();
        Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<T> GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
        bool Save();
    }
}
