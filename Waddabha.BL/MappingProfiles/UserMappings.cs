using AutoMapper;
using Waddabha.BL.DTOs.Auth;
using Waddabha.BL.DTOs.Users;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.MappingProfiles
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {

            CreateMap<UserRegisterDTO, User>().ForMember(dest => dest.Image, opt => opt.Ignore());

            CreateMap<UserLoginDTO, User>().ReverseMap();
            CreateMap<User, GetUserDTO>().ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));

            CreateMap<Image, ImageDto>().ReverseMap();

            CreateMap<EditUserDTO, User>().ReverseMap();

        }
    }
}
