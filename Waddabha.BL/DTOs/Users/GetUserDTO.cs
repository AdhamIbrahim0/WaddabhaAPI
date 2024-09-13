using System.ComponentModel.DataAnnotations;

namespace Waddabha.BL.DTOs.Users
{
    public class GetUserDTO
    {
        public string Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public ImageDto Image { get; set; }
        public string? Gender { get; set; }
    }

    public class ImageDto
    {
        public string ImageUrl { get; set; }
        public string PublicId { get; set; }
    }

}
