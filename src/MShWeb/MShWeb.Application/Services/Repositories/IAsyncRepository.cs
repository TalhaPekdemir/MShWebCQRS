using Microsoft.EntityFrameworkCore.Query;
using MShWeb.Domain.Entities;
using System.Linq.Expressions;

namespace MShWeb.Application.Services.Repositories
{
    public interface IAsyncRepository<TEntity, TEntityId> : IUnitOfWork where TEntity : Entity<TEntityId>
    {
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);

        // TODO add pagination
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);

        Task<TEntity> CreateAsync(TEntity entity);
        Task<ICollection<TEntity>> CreateManyAsync(ICollection<TEntity> entities);

        Task<TEntity> UpdateAsync(TEntity entity);
        
        Task<TEntity> DeleteAsync(TEntity entity, bool isSoft);
    }
}
