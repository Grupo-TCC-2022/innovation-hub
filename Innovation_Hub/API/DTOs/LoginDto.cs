using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "E-mail ou apelido são necessários para login")]
        public string Emailorusername { get; set; }
        [Required(ErrorMessage = "Senha é necessária para login")]
        public string Password { get; set; }
    }
}