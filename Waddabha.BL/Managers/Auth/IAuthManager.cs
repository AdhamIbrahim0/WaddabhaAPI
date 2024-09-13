using Waddabha.BL.DTOs.Auth;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.Managers.Auth
{
    public interface IAuthManager
    {
        Task<string> Register(UserRegisterDTO userDTO);
        Task<string> Login(UserLoginDTO userDTO);
        Task<string> AdminLogin(UserLoginDTO userDTO);
        Task<string> GenerateJWT(User user);
    }
}
