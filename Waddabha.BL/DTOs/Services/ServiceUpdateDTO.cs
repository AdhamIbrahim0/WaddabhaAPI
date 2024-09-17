using Microsoft.AspNetCore.Http;
using Waddabha.BL.DTOs.Users;
using Waddabha.DAL.Data.Enums;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.DTOs.Services
{
    public class ServiceUpdateDTO
    {
        public string? Name { get; set; }
        public decimal? InitialPrice { get; set; }
        public string? Description { get; set; }
        public string? BuyerInstructions { get; set; }
        public Status? Status { get; set; }

        // New images to be uploaded
        public List<IFormFile>? NewImages { get; set; }

        public string? CategoryId { get; set; }
    }
}
