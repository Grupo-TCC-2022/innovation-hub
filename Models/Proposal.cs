using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using innovation_hub.Models.Enums;

namespace innovation_hub.Models
{
    public class Proposal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Título")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Restrição de Idade")]
        public int AgeRestriction { get; set; }
        public bool Finished { get; set; } = false;
        public bool Arquived { get; set; } = false;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int Votes { get; set; } = 0;
        [Display(Name = "Privado")]
        public bool Private { get; set; } = false;
        public ICollection<InterestArea> Categories { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Phase> Phases { get; set; }
        public ICollection<AppUserProposal> AppUserProposals { get; set; }
        [Display(Name = "Tipo de Proposta")]
        public ProposalTypeEnum ProposalType { get; set; }
        public int ManagerId { get; set; }
    }
}