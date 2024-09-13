using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Channels;
using System.Threading.Tasks;
using Waddabha.BL.DTOs.Users;
using Waddabha.DAL;
using Waddabha.DAL.Data.Models;
using Waddabha.DAL.Repositories.Users;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Waddabha.BL.Managers.Users
{
    public class UserManager : IUserManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;


        public UserManager(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<GetUserDTO> GetUserFromTokenAsync(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException(nameof(token), "Token is required");
            }

            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = null;
            var data = handler.ReadJwtToken(token);
            var userId = data.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = await _unitOfWork.UserRepository.GetUserProfileAsync(userId);
            var result = _mapper.Map<User, GetUserDTO>(user);
            return result;
            }

   
    }
}
