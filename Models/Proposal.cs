using System;
using System.Collections.Generic;

namespace innovation_hub.Models
{
    public class Proposal
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int RestrictionAge { get; set; }
        public bool Finished { get; set; }
        public bool Archived { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int Votes { get; set; }
        public bool Private { get; set; }
        public string Category { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Phase> Phases { get; set; }
        public ICollection<AppUserProposal> TeamMembers { get; set; }
    }
}