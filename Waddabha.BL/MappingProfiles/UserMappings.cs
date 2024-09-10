using AutoMapper;
using Microsoft.AspNetCore.Http;
using Waddabha.BL.DTOs.Auth;
using Waddabha.BL.DTOs.Users;
using Waddabha.BL.Managers.UploadImage;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.MappingProfiles
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {

            CreateMap<UserRegisterDTO, User>()
                           .ForMember(dest => dest.Image, opt => opt.Ignore());

            CreateMap<UserLoginDTO, User>().ReverseMap();
            CreateMap<GetUserDTO, User>().ReverseMap();
            CreateMap<EditUserDTO, User>().ReverseMap();

        }
    }
}
