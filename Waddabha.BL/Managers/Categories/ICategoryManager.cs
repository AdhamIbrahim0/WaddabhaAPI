using Waddabha.BL.DTOs.Categories;

namespace Waddabha.BL.Managers.Categories
{
    public interface ICategoryManager
    {
        IEnumerable<CategoryReadDTO> GetAll();
        CategoryReadDTO GetById(int id);
        CategoryReadDTO Update(int id, CategoryUpdateDTO categoryUpdateDTO);
        CategoryReadDTO Add(CategoryAddDTO categoryAddDTO);
        void Delete(int id);

    }
}
