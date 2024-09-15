using Waddabha.BL.DTOs.Categories;
using Waddabha.BL.DTOs.Users;
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
        public string RejectionMessage { get; set; } = string.Empty;
        public string Status { get; set; }
        public double? Rating { get; set; }
        public string CategoryId { get; set; }
        public CategoryReadDTO Category { get; set; }
        public SellerReadDTO Seller { get; set; }
    }
}
