using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using innovation_hub.Data;
using innovation_hub.Models;
using innovation_hub.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace innovation_hub.Controllers
{
    // A FAZER: Validações
    public class FeedController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        // Como o feed trabalha com as propostas, usei o repositorio da proposta aqui
        private readonly IProposalRepository _proposalRepository;

        public FeedController(ILogger<HomeController> logger, DataContext context, IProposalRepository proposalRepository)
        {
            _logger = logger;
            _context = context;
            _proposalRepository = proposalRepository;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,AgeRestriction,Finished,Arquived,CreationDate,Votes,Private,ProposalType")] Proposal proposal, List<string> ProposalCategories, string teamMembers)
        {
            if (ModelState.IsValid)
            {
                // Criar lista de areas de interesse
                List<InterestArea> categories = new List<InterestArea>();

                foreach (string item in ProposalCategories)
                {
                    InterestArea category = new InterestArea();
                    category.Category = (CategoryEnum)Enum.Parse(typeof(CategoryEnum), item);
                    categories.Add(category);
                }

                proposal.Categories = categories;

                _context.Add(proposal);
                await _context.SaveChangesAsync();

                // Set team members
                List<AppUserProposal> aup = new List<AppUserProposal>();
                if (teamMembers != null && teamMembers != "")
                {
                    string[] teamMembersList = teamMembers.Split(",");
                    aup = new List<AppUserProposal>();
                    foreach (string member in teamMembersList)
                    {
                        if (member != User.FindFirst("username").Value)
                        {
                            AppUser userMember = _context.AppUsers.FirstOrDefault(p => p.Nickname == member);
                            if (userMember != null)
                            {
                                aup.Add(new AppUserProposal
                                {
                                    AppUserId = userMember.Id,
                                    ProposalId = proposal.Id
                                });
                            }
                        }
                    }
                }

                AppUser ManagerMember = _context.AppUsers.FirstOrDefault(p => p.Nickname == User.FindFirst("username").Value);
                aup.Add(new AppUserProposal
                {
                    AppUserId = ManagerMember.Id,
                    ProposalId = proposal.Id
                });

                proposal.ManagerId = ManagerMember.Id;

                proposal.AppUserProposals = aup;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
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

        [Authorize]
        public IActionResult Index()
        {
            // Enviar propostas para popular o feed
            ViewBag.Proposals = _context.Proposals.Include(b => b.Categories).Include(c => c.Comments).ToList();
            // Popular a viewbag com todas as categorias enum
            InterestArea interestArea = new InterestArea();
            ViewBag.Categories = interestArea.Categories;
            // Buscar propostas que dei like para marcar o icone de like como já usado
            ViewBag.ProposalsILiked = _context.AppUserProposalVote.Where(p => p.AppUserId == Int32.Parse(User.FindFirst("id").Value) && p.Voted == true).ToList();
            ViewBag.CommentsILiked = _context.AppUserCommentVote.Where(p => p.AppUserId == Int32.Parse(User.FindFirst("id").Value) && p.Voted == true);
            ViewBag.ProposalsIFavorited = _context.AppUserProposalFavorite.Where(p => p.AppUserId == Int32.Parse(User.FindFirst("id").Value) && p.Favorited == true);
            return View();
        }
    }
}