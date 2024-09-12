using Waddabha.DAL.Data.Enums;

namespace Waddabha.DAL.Data.Models
{
    public class Notification : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Url { get; set; }

        public Alert Alert { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
