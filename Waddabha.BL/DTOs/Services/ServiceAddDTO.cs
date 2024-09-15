using Microsoft.AspNetCore.Http;
using Waddabha.DAL.Data.Enums;

namespace Waddabha.BL.DTOs.Services
{
    public class ServiceAddDTO
    {
        public string Name { get; set; }
        public decimal InitialPrice { get; set; }
        public string Description { get; set; }
        public string BuyerInstructions { get; set; }
        public List<IFormFile> Images { get; set; }
        public Status Status { get; set; }
        public string CategoryId { get; set; }
        public string SellerId { get; set; }
    }
}
