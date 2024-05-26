using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MShWeb.Application.Services.Products;
using MShWeb.Domain.Entities;

namespace MShWeb.Application.Features.Products.Queries.GetAll
{
    public class GetAllProductQuery : IRequest<List<GetAllProductQueryDto>>
    {
        public class GetAllProductQUeryHandler : IRequestHandler<GetAllProductQuery, List<GetAllProductQueryDto>>
        {
            private readonly IMapper _mapper;
            private readonly IProductService _productService;

            public GetAllProductQUeryHandler(IMapper mapper, IProductService productService)
            {
                _mapper = mapper;
                _productService = productService;
            }

            public async Task<List<GetAllProductQueryDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
            {
                List<Product> products = await _productService.GetAllAsync(include: p => p.Include(p => p.Images));

                var response = _mapper.Map<List<GetAllProductQueryDto>>(products);

                return response;
            }
        }
    }
}
