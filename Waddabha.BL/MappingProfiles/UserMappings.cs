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
            CreateMap<UserRegisterDTO, User>().ReverseMap();
            CreateMap<UserLoginDTO, User>().ReverseMap();
            CreateMap<GetUserDTO, User>().ReverseMap();

        }
    }
}
