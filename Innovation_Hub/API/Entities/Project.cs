using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Project : Proposal
    {
        public bool IsPrivate { get; set; }
        public IEnumerable<Phase> Phases { get; set; }
        public AppUser ProjectManager { get; set; }
        public IEnumerable<Social> Socials { get; set; }
    }
}