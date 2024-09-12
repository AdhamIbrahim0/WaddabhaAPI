using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waddabha.BL.DTOs.Contracts
{
    public class ContractAddDTO 
    {
        public decimal Price { get; set; }
        public DateTime? StartDate { get; set;}
        public DateTime? EndDate { get; set;}
        public string? WorkLocation { get; set;}
        public string? Description { get; set;}
        public string ServiceId { get; set;}
        public string BuyerId { get; set;}
        public string SellerId { get; set;}
    }
}
