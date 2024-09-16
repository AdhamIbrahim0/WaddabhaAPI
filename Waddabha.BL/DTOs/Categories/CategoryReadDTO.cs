using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.DTOs.Categories
{
    public class CategoryReadDTO : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Image Image { get; set; }
        public ICollection<Service>? Services { get; set; }
    }
}
