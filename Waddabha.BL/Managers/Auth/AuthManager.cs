using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Waddabha.BL.DTOs.Auth;
using Waddabha.BL.Managers.UploadImage;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.Managers.Auth
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IUploadImage _uploadImage;
        public AuthManager(IUploadImage uploadImage, UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _configuration = configuration;
            _uploadImage = uploadImage;

        }
        public async Task<string> Register(UserRegisterDTO userDTO)
        {
            User user = _mapper.Map<UserRegisterDTO, User>(userDTO);
            var uploadResult = await _uploadImage.UploadImageOnCloudinary(userDTO.Image);
            user.Image = uploadResult;

            var result = await _userManager.CreateAsync(user, userDTO.Password);
            
            if (result.Succeeded && userDTO.Role != "Admin") // Enum
            {
                await _userManager.AddToRoleAsync(user, userDTO.Role);
                return await GenerateJWT(user);
            }
            else
            {
                throw new Exception(result.Errors.First().Description);
            }
        }

        public async Task<string> Login(UserLoginDTO userDTO)
        {
            User? user = await _userManager.FindByEmailAsync(userDTO.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, userDTO.Password, false, false);
                if (result.Succeeded)
                {
                    Console.WriteLine("Welcome");
                    return await GenerateJWT(user);
                }
            }
            throw new Exception("Invalid email or password");
        }

        public async Task<string> GenerateJWT(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JwtSettings:Secret"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub , user.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:ExpiryMinutes"])),
                signingCredentials: creds,
                claims: claims
               );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
