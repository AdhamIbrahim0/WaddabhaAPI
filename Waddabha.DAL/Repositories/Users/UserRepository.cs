using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Waddabha.DAL.Data.Context;
using Waddabha.DAL.Data.Models;
using Waddabha.DAL.Repositories.Generic;

namespace Waddabha.DAL.Repositories.Users
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<User> GetUserProfileAsync(string id)
        {
            return await _context.Users.Include(u => u.Image).FirstOrDefaultAsync(u => u.Id == id);



        }
    
        public async Task<User> FindByEmail(string email)
        {
        return   await  _context.Users.FirstOrDefaultAsync(c => c.Email == email);

        }
    }
}
