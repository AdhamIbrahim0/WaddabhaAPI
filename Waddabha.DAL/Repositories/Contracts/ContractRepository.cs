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
                                 .Where(c => c.SellerId == userId).Include(c=>c.Service).Include(c=>c.Buyer)
                                 .ToListAsync(); 
        }
    }
}
