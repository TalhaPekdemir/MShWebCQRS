using AutoMapper;
using MShWeb.Application.Features.Products.Commands.Create;
using MShWeb.Domain.Entities;

namespace MShWeb.Application.Features.Products.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<CreatedProductResponse, Product>().ReverseMap();
        }
    }
}
