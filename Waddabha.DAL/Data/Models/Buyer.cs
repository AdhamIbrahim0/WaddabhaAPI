﻿using System.Text.Json.Serialization;

namespace Waddabha.DAL.Data.Models
{
    public class Buyer : User
    {
        public virtual ICollection<Contract>? Contracts { get; set; }
        [JsonIgnore]
        public virtual ICollection<ChatRoom>? ChatRooms { get; set; }
    }
}
