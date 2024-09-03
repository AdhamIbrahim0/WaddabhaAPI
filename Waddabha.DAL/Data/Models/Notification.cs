namespace Waddabha.DAL.Data.Models
{
    public class Notification : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Category { get; set; } // Enum
    }
}
