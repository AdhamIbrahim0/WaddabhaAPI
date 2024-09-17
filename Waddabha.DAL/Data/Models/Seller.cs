using System.Text.Json.Serialization;

namespace Waddabha.DAL.Data.Models
{
    public class Seller : User
    {
        public string? JobTitle { get; set; }
        public virtual ICollection<Service>? Services { get; set; }
        public virtual ICollection<Contract>? Contracts { get; set; }
        [JsonIgnore]
        public virtual ICollection<ChatRoom>? ChatRooms { get; set; }
    }
}
