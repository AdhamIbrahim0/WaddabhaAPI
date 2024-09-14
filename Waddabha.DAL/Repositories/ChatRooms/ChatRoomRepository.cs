using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waddabha.DAL.Data.Context;
using Waddabha.DAL.Data.Models;
using Waddabha.DAL.Repositories.Generic;


namespace Waddabha.DAL.Repositories.ChatRooms
{
    public class ChatRoomRepository: GenericRepository<ChatRoom>,IChatRoomRepository
    {


        public ChatRoomRepository(ApplicationDbContext context) : base(context)
        {
          
        }

        public async Task<IEnumerable<ChatRoom>> GetChatRoomsByUserId(string userId)
        {
            return await _context.Set<ChatRoom>()
               .Where(m => m.BuyerId == userId || m.SellerId == userId)
               .OrderBy(m => m.CreatedAt).ToListAsync();
               
        }
    }
}
