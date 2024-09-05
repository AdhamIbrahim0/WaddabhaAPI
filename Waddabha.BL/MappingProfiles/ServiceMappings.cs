using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waddabha.BL.DTOs.Services;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.MappingProfiles
{
    public class ServiceMappings : Profile
    {
        public ServiceMappings()
        {
            CreateMap<ServiceReadDTO,Service>().ReverseMap();
        }
    }
}
