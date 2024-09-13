using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waddabha.DAL.Data.Models
{
    public class ChatRoom:BaseEntity
    {
        public ICollection<Message>? Messages { get; set; }
        public virtual Contract? Contract { get; set; }
        public int ContractId { get; set; }
    }
}
