using Microsoft.AspNetCore.Identity;

namespace Waddabha.DAL.Data.Models
{
    public class User : IdentityUser
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string? Gender { get; set; } //Enum
        public virtual ICollection<Notification>? Notifications { get; set; }
        public virtual ICollection<Message>? Messages { get; set; }
    }
}
