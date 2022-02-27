using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "This field is required")]
        public string Emailorusername { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }
    }
}