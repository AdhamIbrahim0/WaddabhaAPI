using System.Text.Json.Serialization;

namespace Waddabha.DAL.Data.Models
{
    public class Buyer : User
    {
        [JsonIgnore]
        public virtual ICollection<Contract>? Contracts { get; set; }
        public virtual ICollection<ChatRoom>? ChatRooms { get; set; }
    }
}
