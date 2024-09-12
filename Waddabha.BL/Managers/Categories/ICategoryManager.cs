using Waddabha.BL.DTOs.Categories;

namespace Waddabha.BL.Managers.Categories
{
    public interface ICategoryManager
    {
        IEnumerable<CategoryReadDTO> GetAll();
        CategoryReadDTO GetById(string id);
        CategoryReadDTO Update(string id, CategoryUpdateDTO categoryUpdateDTO);
        Task<CategoryReadDTO> Add(CategoryAddDTO categoryAddDTO);
        void Delete(string id);
    }
}
