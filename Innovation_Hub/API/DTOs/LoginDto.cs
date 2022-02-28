using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

/*O namespace DTOs se refere ao meio termo entre o que chega da aplicacao client/cliente
e o servidor, ou o inverso, o meio termo entre o que vem do servidor e a aplicacao cliente,
se o aplicativo client no front-end pedir uma lista de usuarios, os usuarios assim que chegarem
do banco de dados se tornarao objetos do tipo DTO usuario, e esses serao enviados como response ao
cliente front-end, assim que o usuario clica no botao de registro, sera enviado um objeto vindo da
form, e se esse objeto coincidir com um objeto DTO ele podera se tornar um DTO
DTO = Data Tranfer Object/Objeto de transferencia de dados*/
namespace API.DTOs
{
    /*Classe LoginDTO, ou seja, assim que se enviar uma request ao server pedindo para logar no app
    e se atingir o end-point de login, o objeto vindo do cliente front-end se tornara um DTO de
    login, que sera tratado por tal end-point*/
    public class LoginDto
    {
        [Required(ErrorMessage = "E-mail ou apelido são necessários para login")]
        public string Emailorusername { get; set; }
        [Required(ErrorMessage = "Senha é necessária para login")]
        public string Password { get; set; }
    }
}