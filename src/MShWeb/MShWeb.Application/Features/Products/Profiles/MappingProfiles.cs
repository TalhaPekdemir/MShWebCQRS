using AutoMapper;
using MShWeb.Application.Features.Products.Commands.Create;
using MShWeb.Application.Features.Products.Queries.GetAll;
using MShWeb.Application.Features.Products.Queries.GetById;
using MShWeb.Domain.Entities;

namespace MShWeb.Application.Features.Products.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateProductCommand, Product>().ForMember(
                p => p.Images, opt => opt.Ignore() // ignore same named IFormFile -> Image conversion
                ).ReverseMap();

            CreateMap<CreatedProductResponse, Product>().ReverseMap();
            CreateMap<GetAllProductQueryDto, Product>().ReverseMap();
            CreateMap<GetByIdProductDto, Product>().ReverseMap();
        }
    }
}
