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

                proposal.AppUserProposals = aup;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Comment(string comment, string proposalId)
        {
            Comment cmt = new Comment
            {
                AppUserId = Int32.Parse(User.FindFirst("id").Value),
                AppUserNickname = User.FindFirst("username").Value,
                CommentText = comment,
                ProposalId = Int32.Parse(proposalId)
            };

            _context.Add(cmt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Vote(string proposalId)
        {
            int appUserId = Int32.Parse(User.FindFirst("id").Value);

            var aupv = await _context.AppUserProposalVote.FirstOrDefaultAsync(p => p.AppUserId == appUserId && p.ProposalId == Int32.Parse(proposalId));
            if (aupv != null)
            {
                aupv.Voted = !aupv.Voted;
            }
            else
            {
                aupv = new AppUserProposalVote
                {
                    AppUserId = Int32.Parse(User.FindFirst("id").Value),
                    ProposalId = Int32.Parse(proposalId),
                    Voted = true
                };
                _context.Add(aupv);
            }

            await _context.SaveChangesAsync();

            var proposal = await _context.Proposals.FirstOrDefaultAsync(p => p.Id == Int32.Parse(proposalId));
            var proposalVotes = _context.AppUserProposalVote.Where(p => p.ProposalId == Int32.Parse(proposalId)).ToList();
            int count = proposalVotes.Sum(s => s.Voted ? 1 : 0);
            proposal.Votes = count;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> VoteComment(string commentId)
        {
            int appUserId = Int32.Parse(User.FindFirst("id").Value);

            var aucv = await _context.AppUserCommentVote.FirstOrDefaultAsync(p => p.CommentId == Int32.Parse(commentId) && p.AppUserId == appUserId);

            if (aucv != null)
            {
                aucv.Voted = !aucv.Voted;
            }
            else
            {
                aucv = new AppUserCommentVote
                {
                    AppUserId = appUserId,
                    CommentId = Int32.Parse(commentId),
                    Voted = true
                };
                _context.Add(aucv);
            }

            await _context.SaveChangesAsync();

            var comment = await _context.Comments.FirstOrDefaultAsync(p => p.Id == Int32.Parse(commentId));
            var commentVotes = _context.AppUserCommentVote.Where(p => p.CommentId == Int32.Parse(commentId)).ToList();
            int count = commentVotes.Sum(s => s.Voted ? 1 : 0);
            comment.Votes = count;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Favorite(string proposalId)
        {
            int appUserId = Int32.Parse(User.FindFirst("id").Value);

            var aupf = await _context.AppUserProposalFavorite.FirstOrDefaultAsync(p => p.AppUserId == appUserId && p.ProposalId == Int32.Parse(proposalId));

            if (aupf != null)
            {
                aupf.Favorited = !aupf.Favorited;
            }
            else
            {
                aupf = new AppUserProposalFavorite
                {
                    AppUserId = Int32.Parse(User.FindFirst("id").Value),
                    ProposalId = Int32.Parse(proposalId),
                    Favorited = true
                };
                _context.Add(aupf);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult Index()
        {
            ViewBag.Proposals = _context.Proposals.Include(b => b.Categories).Include(c => c.Comments).ToList();
            InterestArea interestArea = new InterestArea();
            ViewBag.Categories = interestArea.Categories;
            ViewBag.ProposalsILiked = _context.AppUserProposalVote.Where(p => p.AppUserId == Int32.Parse(User.FindFirst("id").Value) && p.Voted == true).ToList();
            ViewBag.CommentsILiked = _context.AppUserCommentVote.Where(p => p.AppUserId == Int32.Parse(User.FindFirst("id").Value) && p.Voted == true);
            ViewBag.ProposalsIFavorited = _context.AppUserProposalFavorite.Where(p => p.AppUserId == Int32.Parse(User.FindFirst("id").Value) && p.Favorited == true);
            return View();
        }
    }
}