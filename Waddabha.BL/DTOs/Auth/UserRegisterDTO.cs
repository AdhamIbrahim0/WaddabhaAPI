using System.ComponentModel.DataAnnotations;

namespace Waddabha.BL.DTOs.Auth
{
    public class UserRegisterDTO
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
