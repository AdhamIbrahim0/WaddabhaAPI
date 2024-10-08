﻿using Microsoft.AspNetCore.Http;

namespace Waddabha.BL.DTOs.Categories
{
    public class CategoryUpdateDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IFormFile Image { get; set; }
    }
}
