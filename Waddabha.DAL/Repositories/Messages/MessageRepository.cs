using Microsoft.EntityFrameworkCore;
using System;
using Waddabha.DAL.Data.Context;
using Waddabha.DAL.Data.Models;
using Waddabha.DAL.Repositories.Generic;

namespace Waddabha.DAL.Repositories.Messages
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
       
      

        public MessageRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Message> AddAsync(Message entity)
        {
            await _context.Set<Message>().AddAsync(entity);
            return entity;
        }
        public async Task<IEnumerable<Message>> GetMessages(string senderId, string receiverId)
        {
            return await _context.Set<Message>()
                .Where(m => (m.SenderId == senderId && m.ReceiverId == receiverId) ||
                            (m.SenderId == receiverId && m.ReceiverId == senderId))
                .OrderBy(m => m.CreatedAt) // Assuming you have a Timestamp or similar property
                .ToListAsync();
        }

    }


}
