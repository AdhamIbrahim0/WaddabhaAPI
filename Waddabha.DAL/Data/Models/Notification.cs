using System.ComponentModel.DataAnnotations.Schema;

namespace Waddabha.DAL.Data.Models
{
    public class Notification : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Url { get; set; }
        public string Category { get; set; } // Enum
        public virtual User User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
    }
}
