using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.Enums;

namespace API.Entities
{
    public abstract class Proposal
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public InterestAreaEnum Category { get; set; }
        public int AgeRestriction { get; set; }
        public List<Comment> Comments { get; set; }
        public bool Finished { get; set; }
        public bool Archived { get; set; }
    }
}