using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;


namespace Core.Persistence
{
    public interface IRepository<T,TId>
         where T : Entity<TId>
    {
        T? Get(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            int? pageIndex = null,
            int? pageSize = null);
        List<T> GetList(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            int? pageIndex = null,
            int? pageSize = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
