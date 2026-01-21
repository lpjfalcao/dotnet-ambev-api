using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {        
        IQueryable<T> GetListByCondition(Expression<Func<T, bool>> expression);
        Task<T> GetByConditionAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByConditionAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task Remove(T entity);
        Task CommitAsync();
    }
}
