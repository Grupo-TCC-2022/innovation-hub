using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.Validations;

namespace API.DTOs
{
    [AtLeastOneProperty("Email", "UserName", ErrorMessage = "You must supply at least one value")]
    public class LoginDto
    {
        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}