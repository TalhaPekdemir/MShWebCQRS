using MShWeb.Domain.Entities;

namespace MShWeb.Application.Services.Repositories
{
    public interface IImageRepository : IAsyncRepository<Image, Guid>
    {
    }
}
