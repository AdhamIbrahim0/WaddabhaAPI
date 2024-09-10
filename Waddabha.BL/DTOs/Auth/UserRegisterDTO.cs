using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Waddabha.DAL.Data.Models;

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
        public IFormFile Image { get; set; }


    }
}
