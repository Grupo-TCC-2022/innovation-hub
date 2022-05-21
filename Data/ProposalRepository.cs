using System.Linq;
using System.Threading.Tasks;
using innovation_hub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace innovation_hub.Data
{
    // Classe que gerencia o banco de propostas, usada tanto pelo feed quanto pela home
    public class ProposalRepository : IProposalRepository
    {
        private readonly DataContext _context;

        public ProposalRepository(DataContext context)
        {
            _context = context;
        }

        /* Fazer comentario, pega a string do comentario, o id da proposta, o id do usuário e o seu apelido para criar um novo usuario */
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

        /* Favoritar */
        public async Task Favorite(int proposalId, int appUserId)
        {
            // Pegar a relação de favoritado entre a pessoa e a proposta no banco
            var aupf = await _context.AppUserProposalFavorite.FirstOrDefaultAsync(p => p.AppUserId == appUserId && p.ProposalId == proposalId);

            /* Verificar se ja existe uma relação, se existe setar o bool de favorito para o seu oposto */
            if (aupf != null)
            {
                aupf.Favorited = !aupf.Favorited;
            }
            else
            /* Caso não tenha uma relação, criar uma nova e setar o bool de favorito para verdadeiro */
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

        // Votar
        public async Task Vote(int proposalId, int appUserId)
        {
            /* Assim como favoritar, o votar é uma relação de booleano, primeiro verificar se já existe uma relação entre aquela pessoa e a proposta */
            var aupv = await _context.AppUserProposalVote.FirstOrDefaultAsync(p => p.AppUserId == appUserId && p.ProposalId == proposalId);

            /* Caso já existe a relação, setar o votado para o seu oposto */
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

            // Pegar a proposta no banco
            var proposal = await _context.Proposals.FirstOrDefaultAsync(p => p.Id == proposalId);
            // Pegar as relações de voto entre pessoas e propostas
            var proposalVotes = _context.AppUserProposalVote.Where(p => p.ProposalId == proposalId).ToList();
            // Fazer contagem de votos verdadeiros e adicionar 1 ao contador
            int count = proposalVotes.Sum(s => s.Voted ? 1 : 0);
            // Atualizar a contagem de votos
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