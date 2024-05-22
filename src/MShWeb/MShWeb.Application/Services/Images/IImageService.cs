using Microsoft.AspNetCore.Http;
using MShWeb.Domain.Entities;
using System.Linq.Expressions;

namespace MShWeb.Application.Services.Images
{
    public interface IImageService
    {
        Task<Image> CreateAsync(IFormFile file);

        Task<List<Image>> CreateManyAsync(List<IFormFile> files, Guid productId);

        Task<Image> UpdateAsync(Image image);

        Task<Image> DeleteAsync(Image image, bool isSoft);

        Task<Image> GetAsync(Expression<Func<Image, bool>> predicate);

        Task<List<Image>> GetAllAsync(Expression<Func<Image, bool>>? predicate = null);
    }
}
