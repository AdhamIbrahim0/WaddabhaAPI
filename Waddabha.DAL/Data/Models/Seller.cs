namespace Waddabha.DAL.Data.Models
{
    public class Seller : User
    {
        public string? JobTitle { get; set; }
        public ICollection<Service>? Services { get; set; }
        public ICollection<Contract>? Contracts { get; set; }
    }
}
