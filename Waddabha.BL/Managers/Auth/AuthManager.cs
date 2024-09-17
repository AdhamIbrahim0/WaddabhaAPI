using AutoMapper;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Waddabha.BL.DTOs.Auth;
using Waddabha.BL.Managers.UploadImage;
using Waddabha.DAL;
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
        private readonly IUnitOfWork _unitOfWork;
        public AuthManager(IUnitOfWork unitOfWork, IUploadImage uploadImage, UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _configuration = configuration;
            _uploadImage = uploadImage;
            _unitOfWork = unitOfWork;

        }
        public async Task<string> Register(UserRegisterDTO userDTO)
        {
            User user;
            if (userDTO.Role == "Buyer")
            {
                user = _mapper.Map<UserRegisterDTO, Buyer>(userDTO);
            }
            else if (userDTO.Role == "Seller")
            {
                user = _mapper.Map<UserRegisterDTO, Seller>(userDTO);
            }
            else
            {
                throw new ArgumentException("Invalid Role");
            }
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

        public async Task<string> AdminLogin(UserLoginDTO userDTO)
        {
            User? user = await _userManager.FindByEmailAsync(userDTO.Email);
            if (user != null)
            {
                bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
                if (!isAdmin) throw new Exception("Access denied");

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
                new Claim(JwtRegisteredClaimNames.Sub , user.Id!),
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
        public async Task FindByEmailAsync(string email)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.FindByEmail(email);

                if (user == null)
                {
                    throw new Exception("User not found.");
                }

                var otp = new Random().Next(100000, 999999);

                user.OTPCode = otp;
                await _unitOfWork.UserRepository.UpdateAsync(user);
                await _unitOfWork.SaveChangesAsync();
                var message = new MimeMessage
                {
                    From = { new MailboxAddress("Waddabha", "waddabha072@gmail.com") },
                    To = { new MailboxAddress(user.Fname, email) },
                    Subject = "Your OTP Code",
                    Body = new TextPart("plain") { Text = $"Your OTP Code is: {otp}" }
                };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                    await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync("waddabha072@gmail.com", "ftad yssu owic xdvl");

                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> VerifyOtpAsync(ResetPassDTO ResetPassDTO)
        {
            var user = await _unitOfWork.UserRepository.FindByEmail(ResetPassDTO.Email);

            if (user == null)
            {
                throw new Exception("User not found.");
            }

            if (user.OTPCode != ResetPassDTO.Code)
            {
                throw new Exception("Invalid OTP code.");
            }
            if (user.OTPCode == ResetPassDTO.Code)
            {

                var passwordHasher = new PasswordHasher<User>();
                user.PasswordHash = passwordHasher.HashPassword(user, ResetPassDTO.Password);

                user.OTPCode = null;

                await _unitOfWork.UserRepository.UpdateAsync(user);

                await _unitOfWork.SaveChangesAsync();
                
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
