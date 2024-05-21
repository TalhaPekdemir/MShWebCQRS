using MShWeb.Application.Services.Repositories;
using MShWeb.Domain.Entities;
using MShWeb.Persistence.Contexts;

namespace MShWeb.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product, Guid, BaseDbContext>, IProductRepository
    {
        public ProductRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
