using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static API.Entities.InterestArea;

namespace API.Controllers
{
    /*Controller responsavel pelos pedidos de cadastro e login na aplicacao*/
    public class AccountController : BaseApiController
    {
        /*Como controller, geralmente sempre precisara ter acesso ao banco para qualquer operacao,
        o banco de dados no caso eh representado pela propriedade _context, que eh inicializada no
        construtor logo abaixo*/
        private readonly DataContext _context;
        /*O usuario ficara logado no sistema mesmo que a pagina seja recarregada, para isso eh
        necessario a propriedade _tokenService, responsavel por gerar um token/chave de acesso
        individual para o usuario*/
        private readonly ITokenService _tokenService;

        /*Inicializacao das propriedades*/
        public AccountController(DataContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        /*Metodo acionado assim que o botao de registro eh clicado no cliente front-end*/
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            /*Checando se nome de usuario/apelido ja existem no sistema, retornando erro se ele
            existe, ja que o apelido eh individual para cada usuario*/
            if (await UserExists(registerDto.UserName)) return BadRequest("Username already exists");

            //Criando objeto areas de interesse
            List<InterestArea> interestAreas = new List<InterestArea>();
            if (registerDto.InterestAreas.Length > 0)
            {
                /*Adicionando cada area de interesse do DTO para o objeto areas de interesse*/
                foreach (var interestArea in registerDto.InterestAreas)
                {
                    interestAreas.Add(new InterestArea(Enum.Parse<InterestAreaEnum>(interestArea)));
                }

            }

            /*Metodo de encriptacao de senha, para a senha nao "voar" pela web na forma literal*/
            using var hmac = new HMACSHA512();

            /*Transformando DTO em objeto de AppUser*/
            var user = new AppUser
            {
                Email = registerDto.Email,
                Name = registerDto.Name,
                LastName = registerDto.LastName,
                Birthday = registerDto.Birthday,
                UserName = registerDto.UserName.ToLower(),
                InterestAreas = interestAreas,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            /*Adicionando usuario ao banco*/
            _context.Users.Add(user);
            /*Salvando usuario no banco*/
            await _context.SaveChangesAsync();

            /*Retornando o apelido do usuario para o cliente front-end, assim como as areas de
            interesse, e o token/chave de login, para ele ja logar assim quando registrar*/
            return new UserDto
            {
                UserName = user.UserName,
                InterestAreas = user.InterestAreas,
                Token = _tokenService.CreateToken(user)
            };
        }

        /*Metodo acionado assim que o botao de login eh clicado no cliente front-end*/
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            /*Verificando se o email/apelido corresponde a algum registrado no banco*/
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == loginDto.Emailorusername) ?? await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Emailorusername);

            if (user == null) return Unauthorized("Invalid login");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return new UserDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            }; ;
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}