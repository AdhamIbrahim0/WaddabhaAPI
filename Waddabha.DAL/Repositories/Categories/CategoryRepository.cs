using Microsoft.EntityFrameworkCore;
using Waddabha.DAL.Data.Context;
using Waddabha.DAL.Data.Models;
using Waddabha.DAL.Repositories.Generic;

namespace Waddabha.DAL.Repositories.Categories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        //public Category GetCategoryWithServices(int id)
        //{
        //    var category = _context.Categories.Include(c => c.Services).FirstOrDefault(c => c.Id == id);
        //    return category;
        //}
    }
}
