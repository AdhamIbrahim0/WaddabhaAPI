using AutoMapper;
using Waddabha.BL.DTOs.Categories;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryReadDTO, Category>().ReverseMap();
        }
    }
}
