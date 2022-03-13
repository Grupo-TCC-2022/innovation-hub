using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Entities.Enums;

namespace API.DTOs
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public InterestAreaEnum Category { get; set; }
        public int AgeRestriction { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
        public bool Finished { get; set; }
        public bool Archived { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int Votes { get; set; }
        public IEnumerable<AppUserProposalDto> TeamMembers { get; set; }
        public bool IsPrivate { get; set; }
        public IEnumerable<Phase> Phases { get; set; }
        public AppUser ProjectManager { get; set; }
        public IEnumerable<Social> Socials { get; set; }
    }
}