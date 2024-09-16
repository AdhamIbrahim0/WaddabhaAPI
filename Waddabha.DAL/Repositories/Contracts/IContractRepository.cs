using Waddabha.DAL.Data.Models;
using Waddabha.DAL.Repositories.Generic;

namespace Waddabha.DAL.Repositories.Contracts
{
    public interface IContractRepository : IGenericRepository<Contract>
    {
        Task<IEnumerable<Contract>> GetContractsByUserId(string userId);
    }
}
