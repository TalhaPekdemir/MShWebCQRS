using Microsoft.EntityFrameworkCore;
using MShWeb.Domain.Entities;

namespace MShWeb.Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }

        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {

        }
    }
}
