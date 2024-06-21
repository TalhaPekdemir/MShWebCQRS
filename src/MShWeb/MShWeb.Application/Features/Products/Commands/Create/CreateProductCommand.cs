using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using MShWeb.Application.Features.Images.Commands.Create;
using MShWeb.Application.Features.Products.Rules;
using MShWeb.Application.Services.Images;
using MShWeb.Application.Services.Products;
using MShWeb.Application.Services.Repositories;
using MShWeb.Domain.Entities;

namespace MShWeb.Application.Features.Products.Commands.Create
{
    public class CreateProductCommand : IRequest<CreatedProductResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IFormFile> Images { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatedProductResponse>
        {
            private readonly IMapper _mapper;
            private readonly IProductService _productService;
            private readonly ProductBusinessRules _productBusinessRules;
            private readonly IImageService _imageService;
            private readonly IUnitOfWork _unitOfWork;

            public CreateProductCommandHandler(IMapper mapper, IProductService productService, ProductBusinessRules productBusinessRules, IImageService imageService, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _productService = productService;
                _productBusinessRules = productBusinessRules;
                _imageService = imageService;
                _unitOfWork = unitOfWork;
            }

            public async Task<CreatedProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                // check business rules
                await _productBusinessRules.ProductNameShouldNotExistWhenCreated(request.Name);

                // create product first to upload images (we need product id)
                Product product = _mapper.Map<Product>(request);

                // save image to webserver
                product.Images = await _imageService.CreateManyAsync(request.Images, product.Id);

                //await _productService.CreateAsync(product);
                await _unitOfWork.GetRepository<Product>().AddAsync(product);
                await _unitOfWork.SaveChangesAsync();

                // map both product and image entities (being used as DTOs and eliminates circular reference 
                CreatedProductResponse response = _mapper.Map<CreatedProductResponse>(product);

                return response;
            }
        }
    }
}

