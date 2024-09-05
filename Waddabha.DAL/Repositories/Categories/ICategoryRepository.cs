using Waddabha.DAL.Data.Models;
using Waddabha.DAL.Repositories.Generic;

namespace Waddabha.DAL.Repositories.Categories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        //Category GetCategoryWithServices(int id);  
    }
}
