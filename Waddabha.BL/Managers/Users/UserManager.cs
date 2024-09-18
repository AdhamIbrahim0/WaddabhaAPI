using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Waddabha.BL.CustomExceptions;
using Waddabha.BL.DTOs.Users;
using Waddabha.DAL;
using Waddabha.DAL.Data.Models;

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
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();
            //var result = _mapper.Map<User, GetUserDTO>(user);
            var result = new GetUserDTO
            {
                Id = user.Id,
                Email = user.Email,
                Fname = user.Fname,
                Lname = user.Lname,
                UserName = user.UserName,
                Role = role,
                Gender = user.Gender.ToString(),
                Image = new ImageDto
                {
                    ImageUrl = user.Image?.ImageUrl ?? string.Empty,
                    PublicId = user.Image?.PublicId ?? string.Empty
                }
            };
            return result;
        }

       /* public async Task<EditUserDTO> Update(EditUserDTO editUserDTO, string userId)
        {
            var existingUser = await _unitOfWork.UserRepository.GetByIdAsync(userId);
            if (existingUser == null)
            {
                throw new RecordNotFoundException();
            }

            _mapper.Map(editUserDTO, existingUser);

            var updatedUser = await _unitOfWork.UserRepository.UpdateAsync(existingUser);
            await _unitOfWork.SaveChangesAsync();

            var updatedUserDTO = _mapper.Map<EditUserDTO>(updatedUser);

            return updatedUserDTO;
        }*/


    }
}
