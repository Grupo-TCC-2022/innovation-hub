using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Idea : Proposal
    {
        public List<AppUser> TeamMembers { get; set; }
    }
}