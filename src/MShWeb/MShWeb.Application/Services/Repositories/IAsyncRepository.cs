using MShWeb.Domain.Entities;
using System.Linq.Expressions;

namespace MShWeb.Application.Services.Repositories
{
    public interface IAsyncRepository<TEntity, TEntityId> where TEntity : Entity<TEntityId>
    {
        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        // TODO add pagination
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>>? predicate = null);

        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);
        
        Task DeleteAsync(TEntity entity);
    }
}
