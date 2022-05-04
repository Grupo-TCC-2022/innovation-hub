using System;
using System.Collections.Generic;

namespace innovation_hub.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Nickname { get; set; }
        public ICollection<Comment> AppUserComments { get; set; }
        public ICollection<InterestArea> InterestAreas { get; set; }
        public ICollection<AppUserProposal> AppUserProposals { get; set; }
    }
}