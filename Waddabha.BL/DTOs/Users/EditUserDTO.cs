using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
