using Waddabha.DAL.Data.Enums;

namespace Waddabha.DAL.Data.Models
{
    public class Contract : BaseEntity
    {
        public decimal Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? WorkLocation { get; set; }
        public string? Description { get; set; }
        public double? Rating { get; set; }
        public string? FeedbackComment { get; set; }

        public Status Status { get; set; } = Status.Pending;
        public string ServiceId { get; set; }
        public Service Service { get; set; }
        
        public ICollection<Buyer> Buyer { get; set; }
        public ICollection<Seller> Seller { get; set; }
    }
}
