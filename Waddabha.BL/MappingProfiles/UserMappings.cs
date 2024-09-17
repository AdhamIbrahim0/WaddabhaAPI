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

            CreateMap<UserRegisterDTO, User>().ForMember(dest => dest.Image, opt => opt.Ignore()).ReverseMap();
            CreateMap<UserRegisterDTO, Buyer>().ForMember(dest => dest.Image, opt => opt.Ignore()).ReverseMap();
            CreateMap<UserRegisterDTO, Seller>().ForMember(dest => dest.Image, opt => opt.Ignore()).ReverseMap();

            CreateMap<SellerReadDTO, Seller>().ForMember(dest => dest.Image, opt => opt.Ignore()).ReverseMap();

            CreateMap<UserLoginDTO, User>().ReverseMap();
            CreateMap<User, GetUserDTO>().ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image)).ReverseMap();
            CreateMap<Buyer, GetUserDTO>().ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image)).ReverseMap();

            // Mapping between Seller and GetUserDTO
            CreateMap<Seller, GetUserDTO>().ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image)).ReverseMap();



            CreateMap<Image, ImageDto>().ReverseMap().ForMember(dest => dest.Service, opt => opt.Ignore());

            CreateMap<EditUserDTO, User>().ReverseMap();

        }
    }
}
