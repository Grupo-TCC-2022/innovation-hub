using System;
using System.ComponentModel.DataAnnotations;

namespace innovation_hub.Models
{
    public class Phase
    {
        [Key]
        public int Id { get; set; }
        public int ProposalId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
    }
}