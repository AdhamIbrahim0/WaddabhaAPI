using Microsoft.AspNetCore.Identity;
using Waddabha.DAL.Data.Enums;

namespace Waddabha.DAL.Data.Models
{
    public class User : IdentityUser
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int? OTPCode { get; set; }

        public Gender? Gender { get; set; }

        public string ImageId { get; set; }
        public Image Image { get; set; }
        public ICollection<Notification>? Notifications { get; set; }
        public ICollection<Message>? Messages { get; set; }
    }
}
