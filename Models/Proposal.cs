using System;
using System.Collections.Generic;
using innovation_hub.Models.Enums;

namespace innovation_hub.Models
{
    public class Proposal
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AgeRestriction { get; set; }
        public bool Finished { get; set; }
        public bool Arquived { get; set; }
        public DateTime CreationDate { get; set; }
        public int Votes { get; set; }
        public bool Private { get; set; }
        public ICollection<InterestArea> Categories { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Phase> Phases { get; set; }
        public ICollection<AppUserProposal> AppUserProposals { get; set; }
        public ProposalTypeEnum ProposalType { get; set; }
    }
}