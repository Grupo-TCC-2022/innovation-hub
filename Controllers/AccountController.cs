using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using innovation_hub.Data;
using innovation_hub.Models;
using innovation_hub.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
            AppUser User = new AppUser
            {
            Email = email, Nome = nome, 
            Sobrenome = sobrenome, Passeword = passeword,
            DateofBirth = DateTime.Now, Nickname = nickName
            };    
            _context.Add(User);  
            await _context.SaveChangesAsync();  
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}