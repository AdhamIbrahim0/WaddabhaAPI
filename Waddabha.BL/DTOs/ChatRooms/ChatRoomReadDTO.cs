using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waddabha.BL.DTOs.Messages;
using Waddabha.BL.DTOs.Users;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.DTOs.ChatRooms
{
    public class ChatRoomReadDTO:BaseEntity
    {
        public virtual Contract? Contract { get; set; }
        public int? ContractId { get; set; }
        public GetUserDTO Seller { get; set; }
        public string SellerId { get; set; }
        public GetUserDTO Buyer { get; set; }
        public string BuyerId { get; set; }
        public IEnumerable<MessageReadDTO> Messages { get; set; }
    }
}
