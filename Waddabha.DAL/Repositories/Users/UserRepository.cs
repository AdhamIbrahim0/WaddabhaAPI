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
        private readonly IConfiguration _configuration;

        public UserRepository(ApplicationDbContext context, IConfiguration configuration) : base(context)
        {
            _configuration = configuration;
        }
        public async Task<User?> FindByTokenAsync(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Secret"]!);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false // We are just decoding, not checking expiry
            };

            ClaimsPrincipal principal;
            try
            {
                principal = handler.ValidateToken(token, tokenValidationParameters, out _);
            }
            catch
            {
                return null; 
            }

            var userId = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return null; 
            }

            return await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
