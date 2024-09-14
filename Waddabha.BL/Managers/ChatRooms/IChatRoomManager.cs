using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waddabha.BL.DTOs.ChatRooms;
using Waddabha.BL.DTOs.Services;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.Managers.ChatRooms
{
   public interface IChatRoomManager
    {
        IEnumerable<ChatRoomReadDTO> GetAll();
        ChatRoomReadDTO GetById(int id);
        ChatRoomReadDTO Add(ChatRoomAddDTO chatRoomAddDTO);
        Task<IEnumerable<ChatRoomReadDTO>> GetChatRoomsByUserId(string userId);
        void Delete(int id);
    }
}
