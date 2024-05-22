using MShWeb.Domain.Entities;
using System.Linq.Expressions;

namespace MShWeb.Application.Services.Images
{
    public interface IImageService
    {
        Task<Image> CreateProductAsync(Image product);

        Task<Image> UpdateProductAsync(Image product);

        Task<Image> DeleteProductAsync(Image product, bool isSoft);

        Task<Image> GetAsync(Expression<Func<Image, bool>> predicate);

        Task<List<Image>> GetAllAsync(Expression<Func<Image, bool>>? predicate = null);
    }
}
