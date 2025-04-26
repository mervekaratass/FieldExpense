using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;


namespace Core.Persistence
{
    public interface IAsyncRepository<T,TId>
        where T : Entity<TId>
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>,IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>,IOrderedQueryable<T>>? orderBy = null,
            int? pageIndex = null,
            int? pageSize = null,
            CancellationToken cancellationToken = default);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>,
            IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            int? pageIndex = null,
            int? pageSize = null,
                CancellationToken cancellationToken = default);
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    }
}
