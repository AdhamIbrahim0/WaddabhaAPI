using Microsoft.EntityFrameworkCore;
using Waddabha.DAL.Data.Context;
using Waddabha.DAL.Data.Models;
using Waddabha.DAL.Repositories.Generic;

namespace Waddabha.DAL.Repositories.Services
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Service>> GetAllServicesByCategory(string id)
        {
            var services = await _context.Services.Include(x => x.Images).Where(x => x.CategoryId == id).AsNoTracking().ToListAsync();
            return services;
        }
    }
}
