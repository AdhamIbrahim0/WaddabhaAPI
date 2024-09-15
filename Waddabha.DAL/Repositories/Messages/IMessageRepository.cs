using Waddabha.DAL.Data.Models;
using Waddabha.DAL.Repositories.Generic;

namespace Waddabha.DAL.Repositories.Messages
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        Task<IEnumerable<Message>> GetMessages(string senderId, string receiverId);
        Task<IEnumerable<Message>> GetMessagesByChatRoomId(string chatRoomId);
    }
}


