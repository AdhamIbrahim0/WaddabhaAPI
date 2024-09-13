namespace Waddabha.BL.DTOs.Services
{
    public class ServiceUpdateDTO
    {
        public string Name { get; set; }
        public decimal InitialPrice { get; set; }
        public string Description { get; set; }
        public string BuyerInstructions { get; set; }
        public List<string> Images { get; set; }
        public int CategoryId { get; set; }
    }
}
