using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MShWeb.Application.Services.Repositories;
using MShWeb.Domain.Entities;
using System.Linq.Expressions;

namespace MShWeb.Persistence.Repositories
{
    public class BaseRepository<TEntity, TEntityId, TContext> : IAsyncRepository<TEntity, TEntityId> where TEntity : Entity<TEntityId> where TContext : DbContext
    {
        protected readonly TContext _context;

        public BaseRepository(TContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            await _context.AddAsync(entity);
            return entity;
        }

        public virtual async Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.CreatedDate = DateTime.UtcNow;
            }

            await _context.AddRangeAsync(entities);

            return entities;
        }

        public virtual Task<TEntity> DeleteAsync(TEntity entity, bool isSoft)
        {
            // ignoring the fact that entities has relationships
            if (isSoft)
            {
                entity.DeletedDate = DateTime.UtcNow;
                _context.Update(entity);
            }
            else
            {
                _context.Remove(entity);
            }

            return Task.FromResult(entity);
        }

        public virtual Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities, bool isSoft)
        {
            // ignoring the fact that entities has relationships
            if (isSoft)
            {
                foreach(TEntity entity in entities)
                {
                    entity.DeletedDate = DateTime.UtcNow;
                }
                
                _context.UpdateRange(entities);
            }
            else
            {
                _context.RemoveRange(entities);
            }

            return Task.FromResult(entities);
        }

        public virtual async Task<TEntity?> GetAsync(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            
            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(query, predicate);
        }

        public virtual async Task<List<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>>? predicate = null, 
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            // like _context.[DbSet].ToList() 
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (include != null) 
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.ToListAsync();
        }

        public virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            _context.Update(entity);

            return Task.FromResult(entity);
        }

        public virtual Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                entity.UpdatedDate = DateTime.Now;
            }

            _context.UpdateRange(entities);

            return Task.FromResult(entities);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
