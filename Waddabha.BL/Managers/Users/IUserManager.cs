using Waddabha.BL.DTOs.Users;

namespace Waddabha.BL.Managers.Users
{
    public interface IUserManager
    {
        Task<GetUserDTO> GetUserFromTokenAsync(string token);
       Task<EditUserDTO> EditUserAsync(EditUserDTO editUserDTO,string username);
    }
}
