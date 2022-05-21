using System.Linq;
using System.Threading.Tasks;
using innovation_hub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace innovation_hub.Data
{
    public class ProposalRepository : IProposalRepository
    {
        private readonly DataContext _context;

        public ProposalRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Comment(string comment, int proposalId, int appUserId, string userName)
        {
            Comment cmt = new Comment
            {
                AppUserId = appUserId,
                AppUserNickname = userName,
                CommentText = comment,
                ProposalId = proposalId
            };

            _context.Add(cmt);
            await _context.SaveChangesAsync();
        }

        public async Task Favorite(int proposalId, int appUserId)
        {
            var aupf = await _context.AppUserProposalFavorite.FirstOrDefaultAsync(p => p.AppUserId == appUserId && p.ProposalId == proposalId);

            if (aupf != null)
            {
                aupf.Favorited = !aupf.Favorited;
            }
            else
            {
                aupf = new AppUserProposalFavorite
                {
                    AppUserId = appUserId,
                    ProposalId = proposalId,
                    Favorited = true
                };
                _context.Add(aupf);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Vote(int proposalId, int appUserId)
        {
            var aupv = await _context.AppUserProposalVote.FirstOrDefaultAsync(p => p.AppUserId == appUserId && p.ProposalId == proposalId);
            if (aupv != null)
            {
                aupv.Voted = !aupv.Voted;
            }
            else
            {
                aupv = new AppUserProposalVote
                {
                    AppUserId = appUserId,
                    ProposalId = proposalId,
                    Voted = true
                };
                _context.Add(aupv);
            }

            await _context.SaveChangesAsync();

            var proposal = await _context.Proposals.FirstOrDefaultAsync(p => p.Id == proposalId);
            var proposalVotes = _context.AppUserProposalVote.Where(p => p.ProposalId == proposalId).ToList();
            int count = proposalVotes.Sum(s => s.Voted ? 1 : 0);
            proposal.Votes = count;

            await _context.SaveChangesAsync();
        }

        public async Task VoteComment(int commentId, int appUserId)
        {
            var aucv = await _context.AppUserCommentVote.FirstOrDefaultAsync(p => p.CommentId == commentId && p.AppUserId == appUserId);

            if (aucv != null)
            {
                aucv.Voted = !aucv.Voted;
            }
            else
            {
                aucv = new AppUserCommentVote
                {
                    AppUserId = appUserId,
                    CommentId = commentId,
                    Voted = true
                };
                _context.Add(aucv);
            }

            await _context.SaveChangesAsync();

            var comment = await _context.Comments.FirstOrDefaultAsync(p => p.Id == commentId);
            var commentVotes = _context.AppUserCommentVote.Where(p => p.CommentId == commentId).ToList();
            int count = commentVotes.Sum(s => s.Voted ? 1 : 0);
            comment.Votes = count;

            await _context.SaveChangesAsync();
        }
    }
}