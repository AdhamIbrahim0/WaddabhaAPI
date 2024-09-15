using System.Text.Json.Serialization;

namespace Waddabha.DAL.Data.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageId { get; set; }
        public Image Image { get; set; }
        [JsonIgnore]
        public virtual ICollection<Service>? Services { get; set; }
    }
}
