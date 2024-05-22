using Microsoft.EntityFrameworkCore.Query;
using MShWeb.Application.Services.Repositories;
using MShWeb.Domain.Entities;
using System.Linq.Expressions;

namespace MShWeb.Application.Services.Products
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            Product createdProduct = await _productRepository.CreateAsync(product);
            return createdProduct;
        }

        public async Task<Product> DeleteProductAsync(Product product, bool isSoft = false)
        {
            Product deletedProduct = await _productRepository.DeleteAsync(product, isSoft);
            return deletedProduct;
        }

        public async Task<List<Product>> GetAllAsync(
            Expression<Func<Product, bool>>? predicate = null,
            Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null
            )
        {
            return await _productRepository.GetAllAsync(predicate, include);
        }

        public async Task<Product> GetAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _productRepository.GetAsync(predicate);
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            Product updatedProduct = await _productRepository.UpdateAsync(product);
            return updatedProduct;
        }
    }
}
