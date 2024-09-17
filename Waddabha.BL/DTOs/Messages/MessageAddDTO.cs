using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waddabha.BL.DTOs.Messages
{
    public class MessageAddDTO
    {
        public string Body { get; set; }
        public string SenderId { get; set; }
        //public string ReceiverId { get; set; }
        public string ChatRoomId { get; set; }
      
    }
}
