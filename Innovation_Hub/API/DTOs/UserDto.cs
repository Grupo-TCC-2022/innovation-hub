using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

/*O namespace DTOs se refere ao meio termo entre o que chega da aplicacao client/cliente
e o servidor, ou o inverso, o meio termo entre o que vem do servidor e a aplicacao cliente,
se o aplicativo client no front-end pedir uma lista de usuarios, os usuarios assim que chegarem
do banco de dados se tornarao objetos do tipo DTO usuario, e esses serao enviados como response ao
cliente front-end, assim que o usuario clica no botao de registro, sera enviado um objeto vindo da
form, e se esse objeto coincidir com um objeto DTO ele podera se tornar um DTO
DTO = Data Tranfer Object/Objeto de transferencia de dados*/
namespace API.DTOs
{
    /*Classe UserDto, responsavel pelo encaminhamento de um objeto usuario para o cliente com
    o token/chave de login especifico*/
    public class UserDto
    {
        public string UserName { get; set; }
        public List<InterestArea> InterestAreas { get; set; }
        public string Token { get; set; }
    }
}