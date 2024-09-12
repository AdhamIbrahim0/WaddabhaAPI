namespace Waddabha.DAL.Data.Models
{
    public class Image : BaseEntity
    {
        public string ImageUrl { get; set; }
        public string PublicId { get; set; }
        public string? ServiceId { get; set; }
        public Service? Service { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }
    }
}
