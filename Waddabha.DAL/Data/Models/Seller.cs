using System.Text.Json.Serialization;

namespace Waddabha.DAL.Data.Models
{
    public class Seller : User
    {
        public string? JobTitle { get; set; }
        [JsonIgnore]
        public virtual ICollection<Service>? Services { get; set; }
        [JsonIgnore]
        public virtual ICollection<Contract>? Contracts { get; set; }
        public virtual ICollection<ChatRoom>? ChatRooms { get; set; }
    }
}
