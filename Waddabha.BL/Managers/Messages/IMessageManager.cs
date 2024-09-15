using Waddabha.BL.DTOs.Messages;

namespace Waddabha.BL.Managers.Messages
{
    public interface IMessageManager
    {
        Task<MessageReadDTO> SendMessageAsync(MessageAddDTO messageAddDTO);
        Task<IEnumerable<MessageReadDTO>> GetMessagesAsync(string senderId, string receiverId);
        Task<IEnumerable<MessageReadDTO>> GetMessagesByChatRoomIdAsync(string chatRoomId);


    }

}

