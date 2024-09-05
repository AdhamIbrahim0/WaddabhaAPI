using Waddabha.BL.DTOs.Categories;

namespace Waddabha.BL.Managers.Categories
{
    public interface ICategoryManager
    {
        IEnumerable<CategoryReadDTO> GetAll();

    }
}
