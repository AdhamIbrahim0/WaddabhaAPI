using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waddabha.BL.DTOs.Categories;
using Waddabha.BL.DTOs.Contracts;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.MappingProfiles
{
    public class ContractMappings : Profile
    {
        
            public ContractMappings()
            {
                CreateMap<ContractReadDTO, Contract>().ReverseMap();
            }
        
    }
}
