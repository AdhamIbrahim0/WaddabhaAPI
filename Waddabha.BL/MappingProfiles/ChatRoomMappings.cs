using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waddabha.BL.DTOs.ChatRooms;
using Waddabha.BL.DTOs.Contracts;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.MappingProfiles
{
    public class ChatRoomMappings:Profile
    {
        public ChatRoomMappings()
        {
            CreateMap<ChatRoom, ChatRoomReadDTO>()
            .ForMember(dest => dest.Buyer, opt => opt.MapFrom(src => src.Buyer))
            .ForMember(dest => dest.Seller, opt => opt.MapFrom(src => src.Seller))
            .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.Messages)).ReverseMap();
            CreateMap<ChatRoomAddDTO, ChatRoom>().ReverseMap();  
        }
    }
}
