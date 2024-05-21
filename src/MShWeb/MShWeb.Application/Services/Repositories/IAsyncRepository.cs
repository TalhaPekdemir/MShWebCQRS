using MShWeb.Domain.Entities;
using System.Linq.Expressions;

namespace MShWeb.Application.Services.Repositories
{
    public interface IAsyncRepository<TEntity, TEntityId> where TEntity : Entity<TEntityId>
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        // TODO add pagination
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null);

        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);
        
        Task DeleteAsync(TEntity entity, bool isSoft);
    }
}
