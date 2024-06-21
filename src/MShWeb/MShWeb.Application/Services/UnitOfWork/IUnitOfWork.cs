using MShWeb.Domain.Entities;

namespace MShWeb.Application.Services.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAsyncRepository<TEntity, Guid> GetRepository<TEntity>() where TEntity : Entity<Guid>;
        Task SaveChangesAsync();
    }
}
