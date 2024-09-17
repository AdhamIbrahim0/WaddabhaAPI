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
                                 .Include(b=>b.Buyer)
                                 .Where(c => c.SellerId == userId || c.BuyerId == userId)                                 
                                 .ToListAsync(); 
        }
        
    }
}
