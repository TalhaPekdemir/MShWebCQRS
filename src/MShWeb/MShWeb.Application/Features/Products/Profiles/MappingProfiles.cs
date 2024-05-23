using AutoMapper;
using MShWeb.Application.Features.Products.Commands.Create;
using MShWeb.Application.Features.Products.Queries.GetAll;
using MShWeb.Domain.Entities;

namespace MShWeb.Application.Features.Products.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // WARN  IFormFile dan string e dönüşürken nasıl map edecek
            CreateMap<CreateProductCommand, Product>().ForMember(
                p => p.Images, opt => opt.Ignore()
                ).ReverseMap();
            CreateMap<CreatedProductResponse, Product>().ReverseMap();
            CreateMap<GetAllProductQueryDto, Product>().ReverseMap();
        }
    }
}
