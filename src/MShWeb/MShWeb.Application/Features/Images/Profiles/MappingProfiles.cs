using AutoMapper;
using MShWeb.Application.Features.Images.Commands.Create;
using MShWeb.Application.Features.Images.Dtos;
using MShWeb.Domain.Entities;

namespace MShWeb.Application.Features.Images.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            AddGlobalIgnore("Item"); // fix for new AutoMapper IEnumarable indexer mapping issue

            CreateMap<Image, CreateImageCommand>().ReverseMap();
            CreateMap<Image, CreatedImageResponse>().ReverseMap();
            
            CreateMap<FileInfo, Image>()
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreationTimeUtc))
                .ForMember(d => d.Source, opt => opt.MapFrom(s => s.Name))
                .ReverseMap();

            CreateMap<Image, ImageDto>().ReverseMap();
        }
    }
}
