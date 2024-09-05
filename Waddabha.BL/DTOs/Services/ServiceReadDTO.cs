using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.DTOs.Services
{
    public class ServiceReadDTO : BaseEntity
    {
        public string Name { get; set; }
        public decimal InitialPrice { get; set; }
        public string Description { get; set; }
        public string BuyerInstructions { get; set; }
        public List<string> Images { get; set; }
        public int BuyersCount { get; set; }
        public string Status { get; set; } = "Pending"; // Enum
        public double? Rating { get; set; }
        public int CategoryId { get; set; }
    }
}
