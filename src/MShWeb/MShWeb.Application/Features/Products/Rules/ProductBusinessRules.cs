using MShWeb.Application.Services.Repositories;
using MShWeb.Domain.Entities;

namespace MShWeb.Application.Features.Products.Rules
{
    public class ProductBusinessRules
    {
        private readonly IProductRepository _productRepository;

        public ProductBusinessRules(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task ProductNameSholdNotExistWhenCreated(string name)
        {
            Product? product = await _productRepository.GetAsync(predicate: p =>  p.Name.ToLower() == name.ToLower());

            if(product != null)
            {
                // TODO try add localization
                throw new Exception("Aynı isimde bir ürün mevcut.");
            }
        }

        //private async Task ProductShouldExistWhenSelected(Product product)
        //{
        //    Product? selectedProduct = _productRepository.GetAsync();
        //}

    }
}
