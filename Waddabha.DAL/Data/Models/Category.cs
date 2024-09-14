namespace Waddabha.DAL.Data.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageId { get; set; }
        public Image Image { get; set; }
        public int ImageId { get; set; }  // Add this if missing
        public virtual ICollection<Service>? Services { get; set; }
    }
}
