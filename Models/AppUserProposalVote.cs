namespace innovation_hub.Models
{
    public class AppUserProposalVote
    {
        public int Id { get; set; }
        public int ProposalId { get; set; }
        public int AppUserId { get; set; }
        public bool Voted { get; set; }
    }
}