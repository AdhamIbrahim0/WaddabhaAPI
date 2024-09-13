using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waddabha.BL.DTOs.Users;

namespace Waddabha.BL.Managers.Users
{
    public interface IUserManager
    {
        Task<GetUserDTO> GetUserFromTokenAsync(string token);

    }
}
