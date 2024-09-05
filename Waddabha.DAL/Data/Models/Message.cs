using System.ComponentModel.DataAnnotations.Schema;

namespace Waddabha.DAL.Data.Models
{
    public class Message : BaseEntity
    {
        public string Body { get; set; }
        public virtual User Sender { get; set; }
        [ForeignKey("Sender")]
        public string SenderId { get; set; }
    }
}
