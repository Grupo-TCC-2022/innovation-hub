using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Entities.Enums;

namespace API.DTOs
{
    public class IdeaDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public InterestAreaEnum Category { get; set; }
        public int AgeRestriction { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public bool Finished { get; set; }
        public bool Archived { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int Votes { get; set; }
        public IEnumerable<AppUserProposalDto> TeamMembers { get; set; }
    }
}