﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.DTOs.Categories
{
    public class CategoryUpdateDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;



    }
}
