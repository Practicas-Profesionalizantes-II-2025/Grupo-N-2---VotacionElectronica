using Datos.Repositories.Contracts;
using Datos.Context;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Datos.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected VotacionContext _context { get; set; }

        public Repository(VotacionContext context)
        {
            this._context = context;
        }

        public IEnumerable<T> FindAll()
        {
            return this._context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await this._context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await this._context.Set<T>().Where(expression).ToListAsync();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._context.Set<T>().Where(expression).ToList();
        }

        public async Task<T> GetById(int id)
        {
            return await this._context.Set<T>().FindAsync(id);
        }

        public void Create(T entity)
        {
            this._context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this._context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this._context.Set<T>().Remove(entity);
        }

        public async Task SaveAsync()
        {
            try
            {
                await this._context.SaveChangesAsync();
                return;
            }
            catch
            {
                throw new Exception("Error saving changes.");
            }
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
