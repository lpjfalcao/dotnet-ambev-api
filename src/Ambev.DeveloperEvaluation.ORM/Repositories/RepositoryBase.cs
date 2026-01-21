using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DefaultContext context;

        public RepositoryBase(DefaultContext context)
        {
            this.context = context;
        }        

        public IQueryable<T> GetListByCondition(Expression<Func<T, bool>> expression)
        {
            return this.context.Set<T>().Where(expression).AsNoTracking();
        }

        public async Task<T> GetByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await this.context
                .Set<T>().
                Where(expression).
                AsNoTracking().
                FirstOrDefaultAsync();
        }

        public async Task<T> GetByConditionAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = this.context.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query
                .Where(expression)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public IQueryable<T> GetAll()
        {
            return this.context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = this.context.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }

        public async Task<T> Create(T entity)
        {
            this.context.Set<T>().Add(entity);
            await CommitAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            this.context.Set<T>().Update(entity);
            await CommitAsync();
            return entity;
        }

        public void Remove(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }

        public async Task CommitAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}
