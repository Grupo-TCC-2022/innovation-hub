using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/*O namespace DTOs se refere ao meio termo entre o que chega da aplicacao client/cliente
e o servidor, ou o inverso, o meio termo entre o que vem do servidor e a aplicacao cliente,
se o aplicativo client no front-end pedir uma lista de usuarios, os usuarios assim que chegarem
do banco de dados se tornarao objetos do tipo DTO usuario, e esses serao enviados como response ao
cliente front-end, assim que o usuario clica no botao de registro, sera enviado um objeto vindo da
form, e se esse objeto coincidir com um objeto DTO ele podera se tornar um DTO
DTO = Data Tranfer Object/Objeto de transferencia de dados*/
namespace API.DTOs
{
    /*Classe RegisterDto, responsavel por converter e tratar o objeto enviado ao server no pedido
    de registro, ao se clicar em cadastrar sera criado um objeto do tipo RegisterDto, que fara as
    devidas validacoes*/
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