using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query;
using MShWeb.Application.Services.Images;
using MShWeb.Application.Services.Repositories;
using MShWeb.Domain.Entities;
using System.Linq.Expressions;

namespace MShWeb.Application.Services.Products
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IImageService _imageService;
        private readonly IUnitOfWork _unitOfWork;


        public ProductManager(IProductRepository productRepository, IUnitOfWork unitOfWork, IImageService imageService)
        {
            _productRepository = productRepository;
            _imageService = imageService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> AddAsync(Product product, List<IFormFile> images)
        {
            // save image to webserver
            product.Images = await _imageService.CreateManyAsync(images, product.Id);

            //await _productService.CreateAsync(product);
            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();

            return product;
        }

        public async Task<Product> DeleteAsync(Product product, bool isSoft = false)
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

        public async Task<Product> GetAsync(
            Expression<Func<Product, bool>> predicate,
            Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null
            )
        {
            return await _productRepository.GetAsync(predicate, include);
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            Product updatedProduct = await _productRepository.UpdateAsync(product);
            return updatedProduct;
        }
    }
}
