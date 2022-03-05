using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Project : Proposal
    {
        public List<AppUser> TeamMembers { get; set; }
        public bool IsPrivate { get; set; }
        public List<Phases> Phases { get; set; }
        public AppUser ProjectManager { get; set; }
        public List<string> Networks { get; set; }
    }
}