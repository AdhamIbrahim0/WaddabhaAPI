namespace Waddabha.DAL.Data.Models
{
    public class Message : BaseEntity
    {
        public string Body { get; set; }
        public string SenderId { get; set; }
        public User Sender { get; set; }
    }
}
