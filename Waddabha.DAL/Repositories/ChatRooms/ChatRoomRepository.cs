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
               .Include(m => m.Buyer)  // Include the Buyer entity
               .ThenInclude(b => b.Image)
               .Include(m => m.Seller) // Include the Seller entity
               .ThenInclude(s => s.Image)
               .OrderBy(m => m.CreatedAt).ToListAsync();
               
        }

        public async Task<ChatRoom> GetChatRoomWithMessages(string id)
        {
            return await _context.Set<ChatRoom>().Include(cr => cr.Messages).Select(cr => new ChatRoom
            {
                Id = cr.Id, ContractId = cr.ContractId, SellerId =  cr.SellerId, BuyerId = cr.BuyerId, Messages = cr.Messages.OrderBy(m => m.CreatedAt).ToList(), CreatedAt = cr.CreatedAt
            }).FirstOrDefaultAsync(cr => cr.Id == id);
        }

    }
}
