using System.ComponentModel.DataAnnotations.Schema;

namespace Waddabha.DAL.Data.Models
{
    public class Contract : BaseEntity
    {
        public decimal? Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? WorkLocation { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; } = "Pending"; // Enum
        public double? Rating { get; set; }
        public string? FeedbackComment { get; set; }
        public virtual Service Service { get; set; }
        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public virtual Buyer Buyer { get; set; }
        [ForeignKey("Buyer")]
        public string BuyerId { get; set; }
        public virtual Seller Seller { get; set; }
        [ForeignKey("Seller")]
        public string SellerId { get; set; }
    }
}
