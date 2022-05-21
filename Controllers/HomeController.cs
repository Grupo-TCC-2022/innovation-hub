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
        private readonly IProposalRepository _proposalRepository;

        public HomeController(ILogger<HomeController> logger, DataContext context, IProposalRepository proposalRepository)
        {
            _logger = logger;
            _context = context;
            _proposalRepository = proposalRepository;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                int id = Int32.Parse(User.FindFirst("id").Value);
                List<Proposal> projetosQueEstou = _context.Proposals.Include(p => p.AppUserProposals).Where(p => p.AppUserProposals.Any(i => i.AppUserId == id)).Include(p => p.Categories).ToList();
                ViewBag.ProposalsIamIn = projetosQueEstou;

                var allProposals = _context.Proposals.ToList();
                List<AppUserProposalFavorite> projetosQueFavoritei = _context.AppUserProposalFavorite.Where(p => p.AppUserId == id && p.Favorited == true).ToList();
                ViewBag.ProposalsIFavorited = allProposals.Where(x => projetosQueFavoritei.Any(y => x.Id == y.ProposalId));

                InterestArea interestArea = new InterestArea();
                ViewBag.Categories = interestArea.Categories;

                ViewBag.ProposalsILiked = _context.AppUserProposalVote.Where(p => p.AppUserId == Int32.Parse(User.FindFirst("id").Value) && p.Voted == true).ToList();
                
                return View();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Comment(string comment, string proposalId)
        {
            await _proposalRepository.Comment(comment, Int32.Parse(proposalId), Int32.Parse(User.FindFirst("id").Value), User.FindFirst("username").Value);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Vote(string proposalId)
        {
            await _proposalRepository.Vote(Int32.Parse(proposalId), Int32.Parse(User.FindFirst("id").Value));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> VoteComment(string commentId)
        {
            await _proposalRepository.VoteComment(Int32.Parse(commentId), Int32.Parse(User.FindFirst("id").Value));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Favorite(string proposalId)
        {
            await _proposalRepository.Favorite(Int32.Parse(proposalId), Int32.Parse(User.FindFirst("id").Value));

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
