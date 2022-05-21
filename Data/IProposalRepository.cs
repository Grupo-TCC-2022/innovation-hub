using System.Threading.Tasks;

namespace innovation_hub.Data
{
    // Interface necessaria para fazer a injeção de dependencia como serviço
    public interface IProposalRepository
    {
        public Task Comment(string comment, int proposalId, int appUserId, string userName);
        public Task Vote(int proposalId, int appUserId);
        public Task VoteComment(int commentId, int appUserId);
        public Task Favorite(int proposalId, int appUserId);
    }
}