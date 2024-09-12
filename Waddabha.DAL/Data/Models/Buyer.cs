namespace Waddabha.DAL.Data.Models
{
    public class Buyer : User
    {
        public ICollection<Contract>? Contracts { get; set; }
    }
}
