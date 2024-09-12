using AutoMapper;
using Waddabha.BL.DTOs.Categories;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.MappingProfiles
{
    public class CategoryMappings : Profile
    {
        public CategoryMappings()
        {
            CreateMap<CategoryReadDTO, Category>().ReverseMap();
            CreateMap<CategoryAddDTO, Category>().ForMember(dest => dest.Image, opt => opt.Ignore());
            CreateMap<CategoryUpdateDTO, Category>().ReverseMap();
        }
    }
}
