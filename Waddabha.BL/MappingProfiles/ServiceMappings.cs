using AutoMapper;
using Waddabha.BL.DTOs.Services;
using Waddabha.BL.DTOs.Users;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.MappingProfiles
{
    public class ServiceMappings : Profile
    {
        public ServiceMappings()
        {
            CreateMap<ServiceReadDTO, Service>().ReverseMap();
            CreateMap<ServiceAddDTO, Service>().ReverseMap();
            CreateMap<ServiceUpdateDTO, Service>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Image, ImageDto>()
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));
        }
    }
}
