using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence
{
    public class EfRepositoryBase<TEntity,TEntityId, TContext> : IRepository<TEntity,TEntityId>, IAsyncRepository<TEntity,TEntityId>
        where TEntity : Entity<TEntityId>
        where TContext: DbContext
    {
        private readonly TContext _context;

        public EfRepositoryBase(TContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await   _context.AddAsync(entity);
            await   _context.SaveChangesAsync(cancellationToken);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public TEntity? Get(Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, 
            int? pageIndex = null,
            int? pageSize = null)
        {
            IQueryable<TEntity> data = _context.Set<TEntity>();

            if (include != null)
                data = include(data);

            if (orderBy != null)
                data = orderBy(data);

            if (pageIndex.HasValue && pageSize.HasValue && pageIndex.Value >= 0)
                data = data.Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value);

            return data.FirstOrDefault(predicate);
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            int? pageIndex = null, int? pageSize = null,
            CancellationToken cancellationToken=default)
        {
            IQueryable<TEntity> data = _context.Set<TEntity>();

            if (include != null)
                data = include(data);

            if (orderBy != null)
                data = orderBy(data);

            if (pageIndex.HasValue && pageSize.HasValue && pageIndex.Value >= 0)
                data = data.Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value);

            return await data.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null, 
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            int? pageIndex = null,
            int? pageSize = null)
        {
            IQueryable<TEntity> data = _context.Set<TEntity>();

            if (predicate != null)
                data = data.Where(predicate);

            if (include != null)
                data = include(data);

            if(orderBy != null) 
                data = orderBy(data);

            // Sayfalama işlemi
            if (pageIndex.HasValue && pageSize.HasValue && pageIndex.Value > 0)
                data = data.Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value);
            else if (pageSize.HasValue)
                data = data.Take(pageSize.Value); // İlk sayfada tüm veriyi almak için

            return data.ToList();
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, 
            int? pageIndex = null, 
            int? pageSize = null,
            CancellationToken cancellationToken=default)
        {
            IQueryable<TEntity> data = _context.Set<TEntity>();

            if (predicate != null)
                data = data.Where(predicate);

            if (include != null)
                data = include(data);

            if (orderBy != null)
                data = orderBy(data);

            // Sayfalama işlemi
            if (pageIndex.HasValue && pageSize.HasValue && pageIndex.Value > 0)
                data = data.Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value);
            else if (pageSize.HasValue)
                data = data.Take(pageSize.Value); // İlk sayfada tüm veriyi almak için

            return await data.ToListAsync(cancellationToken);


        }


    }
}
