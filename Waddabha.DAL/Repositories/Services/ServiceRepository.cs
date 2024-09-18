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
                .OrderBy(x => x.CreatedAt)
                .Where(x => x.CategoryId == id && x.Status == Status.Accepted).AsNoTracking().ToListAsync();
            return services;
        }

        public async Task<IEnumerable<Service>> GetMyServices(string userId)
        {
            var services = await _context.Services
                .Include(x => x.Seller)
                .Include(x => x.Images)
                .Include(s => s.Category)
                .OrderBy(x => x.CreatedAt)
                .Where(x => x.SellerId == userId).AsNoTracking().ToListAsync();
            return services;
        }

        public async Task<IEnumerable<Service>> GetServicesByStatus(Status status)
        {
            var services = await _context.Services
                .Include(x => x.Seller)
                .Include(x => x.Images)
                .Include(s => s.Category)
                .OrderBy(x => x.CreatedAt)
                .Where(x => x.Status == status).AsNoTracking().ToListAsync();
            return services;
        }

        public async Task<Service> GetByIdWithSeller(string id)
        {
            var service = await _context.Services
                .Include(s => s.Images)
                .Include(s => s.Category)
                .Include(s => s.Seller).ThenInclude(s => s.Image)
                .FirstOrDefaultAsync(s => s.Id == id);
            return service;
        }

        public async Task<IEnumerable<Service>> GetServicesByUserId(string userId)
        {
            return await _context.Services
                               .Where(c => c.SellerId == userId)
                                .OrderBy(c => c.CreatedAt)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Service>> GetAllServicesByName(string name)
        {
            var services = await _context.Services
                            .Include(x => x.Seller)
                            .Include(x => x.Images)
                            .Include(s => s.Category)
                            .Where(x => x.Name.ToLower().Contains(name.ToLower()) && x.Status == Status.Accepted)
                            .OrderBy(x => x.CreatedAt).AsNoTracking().ToListAsync();
            return services;
        }
    }
}
