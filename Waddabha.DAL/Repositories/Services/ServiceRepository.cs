using Microsoft.EntityFrameworkCore;
using Waddabha.DAL.Data.Context;
using Waddabha.DAL.Data.Enums;
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
            var services = await _context.Services
                .Include(x => x.Seller)
                .Include(x => x.Images)
                .Include(s => s.Category)
                .Where(x => x.CategoryId == id).AsNoTracking().ToListAsync();
            return services;
        }

        public async Task<IEnumerable<Service>> GetServicesByStatus(Status status)
        {
            var services = await _context.Services
                .Include(x => x.Seller)
                .Include(x => x.Images)
                .Include(s => s.Category)
                .Where(x => x.Status == status).AsNoTracking().ToListAsync();
            return services;
        }

        public async Task<Service> GetByIdWithSeller(string id)
        {
            var service = await _context.Services
                .Include(s => s.Images)
                .Include(s => s.Category)
                .Include(s => s.Seller)
                .FirstOrDefaultAsync(s => s.Id == id);
            return service;
        }
    }
}
