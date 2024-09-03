using System.ComponentModel.DataAnnotations;

namespace Waddabha.BL.DTOs.Auth
{
    public class UserLoginDTO
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
