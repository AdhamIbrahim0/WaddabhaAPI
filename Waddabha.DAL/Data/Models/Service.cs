using Waddabha.DAL.Data.Enums;

namespace Waddabha.DAL.Data.Models
{
    public class Service : BaseEntity
    {
        public string Name { get; set; }
        public decimal InitialPrice { get; set; }
        public string Description { get; set; }
        public string BuyerInstructions { get; set; }
        public int BuyersCount { get; set; }
        public double? Rating { get; set; }

        public Status Status { get; set; } = Status.Pending;
        public ICollection<Image> Images { get; set; } = new List<Image>();
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public string SellerId { get; set; }
        public Seller Seller { get; set; }
        public ICollection<Contract>? Contracts { get; set; }
    }
}
