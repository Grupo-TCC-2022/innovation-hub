using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "E-mail é necessário para cadastro")]
        [StringLength(50, ErrorMessage = "E-mail deve ter entre 5 e 50 caracteres", MinimumLength = 5)]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "Nome é necessário para cadastro")]
        [StringLength(50, ErrorMessage = "Nome deve ter entre 5 e 50 caracteres", MinimumLength = 5)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Sobrenome é necessário para cadastro")]
        [StringLength(50, ErrorMessage = "Sobrenome deve ter entre 5 e 50 caracteres", MinimumLength = 5)]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Data de nascimento é necessária para cadastro")]
        public DateTime Birthday { get; set; }


        [Required(ErrorMessage = "Apelido é necessário para cadastro")]
        [StringLength(50, ErrorMessage = "Apelido deve ter entre 5 e 50 caracteres", MinimumLength = 5)]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Selecione pelo menos uma área de interesse"), MinLength(1, ErrorMessage = "Selecione pelo menos uma área de interesse")]
        public string[] InterestAreas { get; set; }


        [Required(ErrorMessage = "Senha é necessária para cadastro")]
        [StringLength(50, ErrorMessage = "Senha deve ter entre 5 e 50 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Confirme a senha")]
        [StringLength(50, ErrorMessage = "Senha deve ter entre 5 e 50 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As senhas não são iguais")]
        public string ConfirmPassword { get; set; }
    }
}