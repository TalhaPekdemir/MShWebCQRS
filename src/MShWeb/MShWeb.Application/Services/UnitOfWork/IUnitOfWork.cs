using MShWeb.Domain.Entities;

namespace MShWeb.Application.Services.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        public IProductRepository ProductRepository { get; }
        public IImageRepository ImageRepository { get; }


        //IAsyncRepository<TEntity, Guid> GetRepository<TEntity>() where TEntity : Entity<Guid>;
        Task SaveChangesAsync();
    }
}
