using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AppUserProposal
    {
        public AppUserProposal() { }
        public AppUserProposal(int AppUserId, int ProposalId)
        {
            this.AppUserId = AppUserId;
            this.ProposalId = ProposalId;
        }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int ProposalId { get; set; }
        public Proposal Proposal { get; set; }
    }
}