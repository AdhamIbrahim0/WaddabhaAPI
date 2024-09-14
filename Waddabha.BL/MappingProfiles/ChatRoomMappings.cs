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
            CreateMap<ChatRoomReadDTO, ChatRoom>().ReverseMap();
            CreateMap<ChatRoomAddDTO, ChatRoom>().ReverseMap();  
        }
    }
}
