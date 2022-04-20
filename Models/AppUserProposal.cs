namespace innovation_hub.Models
{
    // Como a classe AppUser tem varias propostas e a classe proposta tem varios AppUsers, é necessario criar uma classe que una ambas
    public class AppUserProposal
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public int ProposalId { get; set; }
    }
}