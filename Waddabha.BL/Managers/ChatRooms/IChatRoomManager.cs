using Waddabha.BL.DTOs.ChatRooms;

namespace Waddabha.BL.Managers.ChatRooms
{
    public interface IChatRoomManager
    {
        Task<IEnumerable<ChatRoomReadDTO>> GetAll();
        Task<ChatRoomReadDTO> GetById(string id);
        Task<ChatRoomReadDTO> Add(ChatRoomAddDTO chatRoomAddDTO);
        Task<IEnumerable<ChatRoomReadDTO>> GetChatRoomsByUserId(string userId);
        void Delete(string id);
    }
}
