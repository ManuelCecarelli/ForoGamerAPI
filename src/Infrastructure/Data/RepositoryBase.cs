using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TEntity>().ToListAsync(cancellationToken);
        }

        public virtual async Task<TEntity?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
        {
            return await _dbContext.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken: cancellationToken);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<TEntity>().Add(entity);

            await SaveChangesAsync(cancellationToken);

            return entity;
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<TEntity>().Update(entity);

            await SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<TEntity>().Remove(entity);

            await SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
