using Waddabha.BL.DTOs.Categories;

namespace Waddabha.BL.Managers.Categories
{
    public interface ICategoryManager
    {
        Task<IEnumerable<CategoryReadDTO>> GetAll();
        Task<CategoryReadDTO> GetById(string id);
        Task<CategoryReadDTO> Update(string id, CategoryUpdateDTO categoryUpdateDTO);
        Task<CategoryReadDTO> Add(CategoryAddDTO categoryAddDTO);
        Task Delete(string id);
    }
}
