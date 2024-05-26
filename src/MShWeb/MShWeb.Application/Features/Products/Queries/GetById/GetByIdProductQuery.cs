using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MShWeb.Application.Features.Products.Rules;
using MShWeb.Application.Services.Products;
using MShWeb.Domain.Entities;

namespace MShWeb.Application.Features.Products.Queries.GetById
{
    public class GetByIdProductQuery : IRequest<GetByIdProductDto>
    {
        public Guid Id { get; set; }

        public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, GetByIdProductDto>
        {

            private readonly IMapper _mapper;
            private readonly IProductService _productService;
            private readonly ProductBusinessRules _businessRules;

            public GetByIdProductQueryHandler(IMapper mapper, IProductService productService, ProductBusinessRules businessRules)
            {
                _mapper = mapper;
                _productService = productService;
                _businessRules = businessRules;
            }

            public async Task<GetByIdProductDto> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
            {
                // business rules
                await _businessRules.ProductShouldExistWhenSelectedById(request.Id);

                Product product = await _productService.GetAsync(
                    predicate: p => p.Id == request.Id, 
                    include: p => p.Include(p => p.Images)
                    );

                GetByIdProductDto result = _mapper.Map<GetByIdProductDto>(product);

                return result;
            }
        }
    }
}
