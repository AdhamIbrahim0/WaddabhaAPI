using Waddabha.DAL.Data.Models;
using Waddabha.DAL.Repositories.Generic;

namespace Waddabha.DAL.Repositories.Users
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> GetUserProfileAsync(string id);
        Task<User> FindByEmail(string email);
    }
}
