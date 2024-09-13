using System.ComponentModel.DataAnnotations;

namespace Waddabha.BL.DTOs.Users
{
    public class EditUserDTO
    {
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Gender { get; set; }
        [EmailAddress]
        public string? Email { get; set; }

    }
}
