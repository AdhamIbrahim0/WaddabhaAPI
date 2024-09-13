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


    }
}
