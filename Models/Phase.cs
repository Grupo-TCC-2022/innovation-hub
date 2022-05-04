using System;

namespace innovation_hub.Models
{
    public class Phase
    {
        public int Id { get; set; }
        public int ProposalId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
    }
}