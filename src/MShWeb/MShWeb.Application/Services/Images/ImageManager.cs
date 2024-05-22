using MShWeb.Domain.Entities;
using System.Linq.Expressions;

namespace MShWeb.Application.Services.Images
{
    public class ImageManager : IImageService
    {
        public Task<Image> CreateProductAsync(Image product)
        {
            throw new NotImplementedException();
        }

        public Task<Image> DeleteProductAsync(Image product, bool isSoft)
        {
            throw new NotImplementedException();
        }

        public Task<List<Image>> GetAllAsync(Expression<Func<Image, bool>>? predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<Image> GetAsync(Expression<Func<Image, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Image> UpdateProductAsync(Image product)
        {
            throw new NotImplementedException();
        }
    }
}
