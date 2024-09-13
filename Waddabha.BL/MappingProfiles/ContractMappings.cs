using AutoMapper;
using Waddabha.BL.DTOs.Contracts;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.MappingProfiles
{
    public class ContractMappings : Profile
    {

        public ContractMappings()
        {
            CreateMap<ContractReadDTO, Contract>().ReverseMap();
            CreateMap<ContractAddDTO, Contract>().ReverseMap();
        }

    }
}
