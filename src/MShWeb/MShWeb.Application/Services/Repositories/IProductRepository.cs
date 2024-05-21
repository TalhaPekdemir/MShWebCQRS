using MShWeb.Domain.Entities;

namespace MShWeb.Application.Services.Repositories
{
    public interface IProductRepository : IAsyncRepository<Product, Guid>
    {
    }
}
