﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity, bool isSoft)
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

            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity?> GetAsync(
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

        public async Task<List<TEntity>> GetAllAsync(
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

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<ICollection<TEntity>> CreateManyAsync(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.CreatedDate = DateTime.UtcNow;
            }

            await _context.AddRangeAsync(entities);
            await _context.SaveChangesAsync();

            return entities;
        }
    }
}
