using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using MShWeb.Application.Features.Products.Rules;
using MShWeb.Application.Services.Repositories;
using MShWeb.Domain.Entities;

namespace MShWeb.Application.Features.Products.Commands.Create
{
    public class CreateProductCommand : IRequest<CreatedProductResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IFormFile>? Images { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatedProductResponse>
        {
            private readonly IMapper _mapper;
            private readonly IProductRepository _productRepository;
            private readonly ProductBusinessRules _productBusinessRules;

            public CreateProductCommandHandler(Mapper mapper, IProductRepository productRepository, ProductBusinessRules productBusinessRules)
            {
                _mapper = mapper;
                _productRepository = productRepository;
                _productBusinessRules = productBusinessRules;
            }

            public async Task<CreatedProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                // check business rules
                await _productBusinessRules.ProductNameSholdNotExistWhenCreated(request.Name);


                // save image to webserver



                // create product after uploading images
                Product product = _mapper.Map<Product>(request);

                await _productRepository.CreateAsync(product);

                CreatedProductResponse response = _mapper.Map<CreatedProductResponse>(product);

                return response;
            }
        }
    }
}
