using Waddabha.BL.DTOs.Users;

namespace Waddabha.BL.Managers.Users
{
    public interface IUserManager
    {
        Task<GetUserDTO> GetUserFromTokenAsync(string token);
    }
}
