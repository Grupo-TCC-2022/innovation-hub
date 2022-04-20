using System;

namespace innovation_hub.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int ProposalId { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; } = DateTime.Now;
        public int Votes { get; set; }
    }
}