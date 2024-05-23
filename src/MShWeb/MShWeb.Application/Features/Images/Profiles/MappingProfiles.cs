using AutoMapper;
using MShWeb.Application.Features.Images.Commands.Create;
using MShWeb.Domain.Entities;

namespace MShWeb.Application.Features.Images.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            AddGlobalIgnore("Item");

            CreateMap<Image, CreateImageCommand>().ReverseMap();
            CreateMap<Image, CreatedImageResponse>().ReverseMap();
        }
    }
}
