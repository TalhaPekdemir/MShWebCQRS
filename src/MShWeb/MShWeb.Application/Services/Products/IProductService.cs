using Microsoft.EntityFrameworkCore.Query;
using MShWeb.Domain.Entities;
using System.Linq.Expressions;

namespace MShWeb.Application.Services.Products
{
    public interface IProductService
    {
        Task<Product> CreateAsync(Product product);

        Task<Product> UpdateAsync(Product product);
            
        Task<Product> DeleteAsync(Product product, bool isSoft);
    
        Task<Product> GetAsync(Expression<Func<Product, bool>> predicate);

        Task<List<Product>> GetAllAsync(Expression<Func<Product, bool>>? predicate = null, Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null);
    }
}
