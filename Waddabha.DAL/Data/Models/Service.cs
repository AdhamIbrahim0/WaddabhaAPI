using System.ComponentModel.DataAnnotations.Schema;

namespace Waddabha.DAL.Data.Models
{
    public class Service : BaseEntity
    {
        public string Name { get; set; }
        public decimal InitialPrice { get; set; }
        public string Description { get; set; }
        public string BuyerInstructions { get; set; }
        public string ImagePath { get; set; }
        public int BuyersCount { get; set; }
        public string Status { get; set; } = "Pending"; // Enum
        public double? Rating { get; set; }
        public virtual Category Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Seller Seller { get; set; }
        [ForeignKey("Seller")]
        public string SellerId { get; set; }
        public virtual ICollection<Contract>? Contracts { get; set; }
    }
}
