using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waddabha.DAL.Data.Models
{
    public class ChatRoom:BaseEntity
    {
        public ICollection<Message>? Messages { get; set; }
        public virtual ICollection<Contract>? Contracts { get; set; }
        
        public string? ContractId { get; set; }
        public virtual Seller Seller { get; set; }
       
        public string SellerId { get; set; }
        public virtual Buyer Buyer { get; set; }
        
        public string BuyerId { get; set; }
    }
}
