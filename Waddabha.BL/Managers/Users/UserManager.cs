using AutoMapper;
using System;
using System.Threading.Tasks;
using Waddabha.BL.DTOs.Users;
using Waddabha.DAL;

namespace Waddabha.BL.Managers.Users
{
    public class UserManager : IUserManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetUserDTO> GetUserFromTokenAsync(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException(nameof(token), "Token is required");
            }

            // Retrieve the user based on the token
            var user = await _unitOfWork.UserRepository.FindByTokenAsync(token);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid token or user not found");
            }

            // Map the User entity to GetUserDTO
            var result = _mapper.Map<GetUserDTO>(user);
            return result;
        }
    }
}
