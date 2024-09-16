using System.Text.Json.Serialization;

namespace Waddabha.DAL.Data.Models
{
    public class Image : BaseEntity
    {
        public string ImageUrl { get; set; }
        public string PublicId { get; set; }
        public string? ServiceId { get; set; }
        [JsonIgnore]
        public Service? Service { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}
