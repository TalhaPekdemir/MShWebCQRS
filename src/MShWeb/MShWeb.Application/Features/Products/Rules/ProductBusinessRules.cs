using MShWeb.Application.Services.Products;
using MShWeb.Application.Services.Repositories;
using MShWeb.Domain.Entities;

namespace MShWeb.Application.Features.Products.Rules
{
    public class ProductBusinessRules
    {
        private readonly IProductService _productService;

        public ProductBusinessRules(IProductService productService)
        {
            _productService = productService;
        }

        public async Task ProductNameShouldNotExistWhenCreated(string name)
        {
            Product? product = await _productService.GetAsync(predicate: p => p.Name.ToLower() == name.ToLower());

            if(product != null)
            {
                // TODO try add localization
                throw new Exception("Aynı isimde bir ürün mevcut.");
            }
        }

        public async Task<Product> ProductShouldExistWhenSelectedById(Guid id)
        {
            Product? product = await _productService.GetAsync(predicate: p => p.Id == id);

            if(product == null) 
            {
                throw new Exception("Product does not exist!");
            }
            else
            {
                return product;
            }
        }

    }
}
