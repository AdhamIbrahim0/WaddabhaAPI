using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waddabha.DAL.Data.Models;
using Waddabha.DAL.Repositories.Generic;


namespace Waddabha.DAL.Repositories.ChatRooms
{
    public interface IChatRoomRepository: IGenericRepository<ChatRoom>
    {
        Task<IEnumerable<ChatRoom>> GetChatRoomsByUserId(string userId);

    }
    

   
}
