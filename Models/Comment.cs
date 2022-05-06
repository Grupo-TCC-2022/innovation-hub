using System;
using System.ComponentModel.DataAnnotations;

namespace innovation_hub.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int ProposalId { get; set; }
        [Required]
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; } = DateTime.Now;
        public int Votes { get; set; } = 0;
    }
}