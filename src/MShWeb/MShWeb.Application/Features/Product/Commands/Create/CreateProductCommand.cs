using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using MShWeb.Application.Services.Repositories;

namespace MShWeb.Application.Features.Product.Commands.Create
{
    public class CreateProductCommand : IRequest<CreateProductResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IFormFile> Images { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
        {
            private readonly Mapper _mapper;
            private readonly IProductRepository _productRepository;

            public CreateProductCommandHandler(Mapper mapper, IProductRepository productRepository)
            {
                _mapper = mapper;
                _productRepository = productRepository;
            }

            public Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
