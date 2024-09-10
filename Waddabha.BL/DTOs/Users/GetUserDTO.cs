﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waddabha.DAL.Data.Models;

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
        public Image Image { get; set; }
        public string? Gender { get; set; }
    }
}
