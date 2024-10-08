﻿using Microsoft.EntityFrameworkCore;
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

        //public async Task<IEnumerable<Message>> GetMessages(string senderId, string receiverId)
        //{
        //    return await _context.Set<Message>()
        //        .Where(m => (m.SenderId == senderId && m.ReceiverId == receiverId) ||
        //                    (m.SenderId == receiverId && m.ReceiverId == senderId))
        //        .OrderBy(m => m.CreatedAt)
        //        .ToListAsync();

        //}
        public async Task<IEnumerable<Message>> GetMessagesByChatRoomId(string chatRoomId)
        {
            return await _context.Set<Message>()
                .Where(m => m.ChatRoomId == chatRoomId)
                .OrderBy(m => m.CreatedAt)
                .ToListAsync();

        }

    }


}
