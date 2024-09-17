using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waddabha.BL.DTOs.Categories;
using Waddabha.BL.DTOs.Messages;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.MappingProfiles
{
    public class MessageMapping:Profile
    {
        public MessageMapping()
        {
            CreateMap<Message, MessageReadDTO>()
                .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.Body))
            .ForMember(dest => dest.SenderId, opt => opt.MapFrom(src => src.SenderId)).ReverseMap();
            //.ForMember(dest => dest.ReceiverId, opt => opt.MapFrom(src => src.ReceiverId));
            CreateMap<MessageAddDTO, Message>()
            .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.Body))
            .ForMember(dest => dest.SenderId, opt => opt.MapFrom(src => src.SenderId))
            //.ForMember(dest => dest.ReceiverId, opt => opt.MapFrom(src => src.ReceiverId))
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

        }
    }
}
