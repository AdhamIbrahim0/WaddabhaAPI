using Microsoft.EntityFrameworkCore;
using System;
using Waddabha.DAL.Data.Context;
using Waddabha.DAL.Data.Models;
using Waddabha.DAL.Repositories.Generic;
using Waddabha.DAL.Repositories.Messages;
  using System.Threading.Tasks;

    namespace Waddabha.DAL.Repositories.Messages
    {
        public interface IMessageRepository : IGenericRepository<Message>
        {
            Task<Message> AddAsync(Message entity); // Define the method directly here
            Task<IEnumerable<Message>> GetMessages(string senderId, string receiverId);
             Task<IEnumerable<Message>> GetMessagesByChatRoomId(int chatRoomId);

    }
    }


