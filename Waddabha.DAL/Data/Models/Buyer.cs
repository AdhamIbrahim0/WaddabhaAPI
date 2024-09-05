namespace Waddabha.DAL.Data.Models
{
    public class Buyer : User
    {
        public virtual ICollection<Contract>? Contracts { get; set; }
    }
}
