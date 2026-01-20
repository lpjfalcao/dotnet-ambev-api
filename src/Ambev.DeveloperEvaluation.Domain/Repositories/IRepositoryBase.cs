using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        void Create(T entity);
        IQueryable<T> GetListByCondition(Expression<Func<T, bool>> expression);
        Task<T> GetByConditionAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByConditionAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);
        void Update(T entity);
        void Remove(T entity);
        Task CommitAsync();
    }
}
