using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace innovation_hub.Models
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        public DateTime DateofBirth { get; set; }
        [Required]
        public string Nickname { get; set; }
        public ICollection<Comment> AppUserComments { get; set; }
        public ICollection<InterestArea> InterestAreas { get; set; }
        public ICollection<AppUserProposal> AppUserProposals { get; set; }
    }
}