namespace innovation_hub.Models
{
    public class AppUserProposalFavorite
    {
        public int Id { get; set; }
        public int ProposalId { get; set; }
        public int AppUserId { get; set; }
        public bool Favorited { get; set; }
    }
}