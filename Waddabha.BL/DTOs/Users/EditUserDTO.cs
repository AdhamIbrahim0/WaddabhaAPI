using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Waddabha.BL.DTOs.Users
{
    public class EditUserDTO
    {
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Gender { get; set; }
        public IFormFile? Image { get; set; }
        public string? JobTitle { get; set; }


    }
}
