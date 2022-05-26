using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using innovation_hub.Data;
using innovation_hub.Models;
using innovation_hub.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace innovation_hub.Controllers
{

    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        private readonly DataContext _context;

        public AccountController(ILogger<AccountController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("register")]
        public async Task<IActionResult> Cadastro(string email, string nome, string sobrenome, string passeword, DateTime dateofBirth, string nickName)
        {
            // A FAZER: Validações
            // A FAZER: Checar se apelido já existe
            AppUser User = new AppUser
            {
                Email = email,
                Nome = nome,
                Sobrenome = sobrenome,
                Passeword = passeword,
                DateofBirth = DateTime.Now,
                Nickname = nickName
            };
            _context.Add(User);
            await _context.SaveChangesAsync();
            return RedirectToAction("Login", new {password = passeword, nickName = nickName});
        }

        public async Task<IActionResult> Login(string password, string nickName)
        {
            // A FAZER: Validações
            // Buscar usuário pelo apelido no banco -> checar se senha confere
            AppUser user = await _context.AppUsers.FirstOrDefaultAsync(p => p.Nickname == nickName);
            if (user.Passeword != password)
            {
                return Error();
            }

            // Processo para criar cookie que guarde id, apelido e nome
            List<Claim> direitosAcesso = new List<Claim>{
                new Claim("id", user.Id.ToString()),
                new Claim("username", user.Nickname),
                new Claim("name", user.Nome)
            };

            var identity = new ClaimsIdentity(direitosAcesso, "Identity.Login");
            var userPrincipal = new ClaimsPrincipal(new[] { identity });

            await HttpContext.SignInAsync(userPrincipal, new AuthenticationProperties
            {
                IsPersistent = false,
                ExpiresUtc = DateTime.Now.AddHours(1)
            });

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
            }

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}