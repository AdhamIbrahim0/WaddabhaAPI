namespace Waddabha.DAL.Data.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageId { get; set; }
        public Image Image { get; set; }
        public virtual ICollection<Service>? Services { get; set; }
    }
}
