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
    public class FeedController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public FeedController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
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
                string[] teamMembersList = teamMembers.Split(",");
                List<AppUserProposal> aup = new List<AppUserProposal>();
                foreach (string member in teamMembersList)
                {
                    AppUser userMember = _context.AppUsers.FirstOrDefault(p => p.Nickname == member);
                    if(userMember != null)
                    {
                        aup.Add(new AppUserProposal{
                            AppUserId = userMember.Id,
                            ProposalId = proposal.Id
                        });
                    }
                    Console.WriteLine(member);
                }
                proposal.AppUserProposals = aup;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Comment(string comment, string proposalId)
        {
            Comment cmt = new Comment{
                AppUserId = Int32.Parse(User.FindFirst("id").Value),
                AppUserNickname = User.FindFirst("username").Value,
                CommentText =  comment,
                ProposalId = Int32.Parse(proposalId)
            };

            _context.Add(cmt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Vote(string proposalId)
        {
            int AppUserId = Int32.Parse(User.FindFirst("id").Value);

            var aupv = await _context.AppUserProposalVote.FirstOrDefaultAsync(p => p.AppUserId == AppUserId && p.ProposalId == Int32.Parse(proposalId));
            if (aupv != null)
            {
                aupv.Voted = !aupv.Voted;
            } else {
                aupv = new AppUserProposalVote{
                    AppUserId = Int32.Parse(User.FindFirst("id").Value),
                    ProposalId = Int32.Parse(proposalId),
                    Voted = true
                };
                _context.Add(aupv);
            }

            var proposal = await _context.Proposals.FirstOrDefaultAsync(p => p.Id == Int32.Parse(proposalId));
            var proposalVotes = _context.AppUserProposalVote.Where(p => p.ProposalId == Int32.Parse(proposalId)).ToList();
            int count = proposalVotes.Sum(s => s.Voted ? 1 : 0);
            proposal.Votes = count;

            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult Index()
        {
            ViewBag.Proposals = _context.Proposals.Include(b => b.Categories).Include(c => c.Comments).ToList();
            InterestArea interestArea = new InterestArea();
            ViewBag.Categories = interestArea.Categories;
            return View();
        }
    }
}