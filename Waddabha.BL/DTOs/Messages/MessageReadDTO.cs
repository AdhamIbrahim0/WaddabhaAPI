using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.DTOs.Messages
{
  public class MessageReadDTO:BaseEntity
    {
       
        public string Body { get; set; }
        public string SenderId { get; set; }
        //public string ReceiverId { get; set; }
        public string ChatRoomId { get; set; }

    }
}
