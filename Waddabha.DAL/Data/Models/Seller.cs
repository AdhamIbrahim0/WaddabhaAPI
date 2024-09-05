namespace Waddabha.DAL.Data.Models
{
    public class Seller : User
    {
        public string? JobTitle { get; set; }
        public virtual ICollection<Service>? Services { get; set; }
        public virtual ICollection<Contract>? Contracts { get; set; }
    }
}
