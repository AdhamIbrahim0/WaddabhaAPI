using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waddabha.BL.DTOs.Contracts;
using Waddabha.BL.DTOs.Messages;

namespace Waddabha.BL.Managers.Messages
{
    public interface IMessageManger
    {
           Task<MessageReadDTO> SendMessageAsync(MessageAddDTO messageAddDTO);
            Task<IEnumerable<MessageReadDTO>> GetMessagesAsync(string senderId, string receiverId);
        Task<IEnumerable<MessageReadDTO>> GetMessagesByChatRoomIdAsync( int chatRoomId);


    }

}

