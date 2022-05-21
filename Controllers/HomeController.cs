using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using innovation_hub.Models;
using innovation_hub.Data;
using Microsoft.EntityFrameworkCore;

namespace innovation_hub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                int id = Int32.Parse(User.FindFirst("id").Value);
                List<Proposal> projetosQueEstou = _context.Proposals.Include(p => p.AppUserProposals).Where(p => p.AppUserProposals.Any(i => i.AppUserId == id)).Include(p => p.Categories).ToList();
                ViewBag.ProposalsIamIn = projetosQueEstou;
                
                var allProposals = _context.Proposals.ToList();
                List<AppUserProposalFavorite> projetosQueFavoritei = _context.AppUserProposalFavorite.Where(p => p.AppUserId == id && p.Favorited == true).ToList();
                ViewBag.ProposalsIFavorited = allProposals.Where(x => projetosQueFavoritei.Any(y => x.Id == y.ProposalId));

                return View();
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
