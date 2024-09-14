using Microsoft.AspNetCore.Http;
using Waddabha.BL.DTOs.Users;
using Waddabha.DAL.Data.Enums;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.DTOs.Services
{
    public class ServiceReadDTO : BaseEntity
    {
        public string Name { get; set; }
        public decimal InitialPrice { get; set; }
        public string Description { get; set; }
        public string BuyerInstructions { get; set; }
        public List<ImageDto> Images { get; set; }
        public int BuyersCount { get; set; }
        public Status Status { get; set; } // Enum
        public double? Rating { get; set; }
        public string CategoryId { get; set; }
    }
}
