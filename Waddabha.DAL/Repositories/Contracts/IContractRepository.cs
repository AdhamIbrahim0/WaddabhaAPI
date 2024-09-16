﻿using Waddabha.DAL.Data.Models;
using Waddabha.DAL.Repositories.Generic;

namespace Waddabha.DAL.Repositories.Contracts
{
    public interface IContractRepository : IGenericRepository<Contract>
    {
    public    Task<IEnumerable<Contract>> GetContractsByUserId(string userId);
    }
}
