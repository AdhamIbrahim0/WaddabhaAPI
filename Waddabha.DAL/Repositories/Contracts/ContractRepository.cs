using Microsoft.EntityFrameworkCore;
using Waddabha.DAL.Data.Context;
using Waddabha.DAL.Data.Models;
using Waddabha.DAL.Repositories.Generic;

namespace Waddabha.DAL.Repositories.Contracts
{
    public class ContractRepository : GenericRepository<Contract>, IContractRepository
    {
        public ContractRepository(ApplicationDbContext context) : base(context)
        {


        }
        public async Task<IEnumerable<Contract>> GetContractsByUserId(string userId)
        {
            return await _context.Contracts
                                 .Include(s => s.Service)
                                 .Include(b => b.Buyer).ThenInclude(b => b.Image)
                                 .Include(b => b.Seller).ThenInclude(b => b.Image)
                                 .Where(c => c.SellerId == userId || c.BuyerId == userId)
                                 .OrderByDescending(c => c.CreatedAt)
                                 .ToListAsync();
        }
        public async Task<Contract> GetContract(string id)
        {
            return await _context.Contracts
                                 .Include(s => s.Service)
                                 .Include(b => b.Buyer).ThenInclude(b => b.Image)
                                 .Include(b => b.Seller).ThenInclude(b => b.Image)
                                 .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
