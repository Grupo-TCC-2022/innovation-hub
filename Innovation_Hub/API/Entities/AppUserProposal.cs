using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AppUserProposal
    {
        public AppUserProposal() { }
        public AppUserProposal(int AppUserId, int ProblemId)
        {
            this.AppUserId = AppUserId;
            this.ProblemId = ProblemId;
        }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int ProblemId { get; set; }
        public Proposal Proposal { get; set; }
    }
}