using AutoMapper;
using Waddabha.BL.DTOs.Services;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.MappingProfiles
{
    public class ServiceMappings : Profile
    {
        public ServiceMappings()
        {
            CreateMap<ServiceReadDTO, Service>().ReverseMap();
            CreateMap<ServiceAddDTO, Service>().ReverseMap();
            CreateMap<ServiceUpdateDTO, Service>().ReverseMap();
        }
    }
}
