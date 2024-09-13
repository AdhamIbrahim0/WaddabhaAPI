using System.ComponentModel.DataAnnotations.Schema;

namespace Waddabha.DAL.Data.Models
{
    public class Message : BaseEntity
    {
        public string Body { get; set; }

        // Foreign Key to the Sender (User)
        [ForeignKey("Sender")]
        public string SenderId { get; set; }

        // Navigation property for Sender
        public virtual User Sender { get; set; }

        // Foreign Key to the Receiver (User)
        [ForeignKey("Receiver")]
        public string ReceiverId { get; set; }

        // Navigation property for Receiver
        public virtual User Receiver { get; set; }

      
    }
}
