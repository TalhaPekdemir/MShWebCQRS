using MShWeb.Application.Services.Repositories;
using MShWeb.Domain.Entities;
using MShWeb.Persistence.Contexts;

namespace MShWeb.Persistence.Repositories
{
    public class ImageRepository : BaseRepository<Image, Guid, BaseDbContext>, IImageRepository
    {
        public ImageRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
