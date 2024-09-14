using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.DTOs.ChatRooms
{
    public class ChatRoomAddDTO
    {
        public virtual Contract? Contract { get; set; }
        public int? ContractId { get; set; }
        public virtual Seller Seller { get; set; }
        public int SellerId { get; set; }
        public virtual Buyer Buyer { get; set; }
        public int BuyerId { get; set; }
    }
}
