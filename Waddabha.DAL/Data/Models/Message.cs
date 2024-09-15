namespace Waddabha.DAL.Data.Models
{
    public class Message : BaseEntity
    {
        public string Body { get; set; }
        // Foreign Key to the Sender (User)
        public string SenderId { get; set; }

        // Navigation property for Sender
        public virtual User Sender { get; set; }

        // Foreign Key to the Receiver (User)
        public string ReceiverId { get; set; }

        // Navigation property for Receiver
        public virtual User Receiver { get; set; }
        public virtual ChatRoom ChatRoom { get; set; }
        public string ChatRoomId { get; set; }
    }
}
