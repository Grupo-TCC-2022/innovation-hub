using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int ProposalId { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; } = DateTime.Now;
        public int VotesCount { get; set; }
        public bool Anonymous { get; set; }
        public string CommentOwner { get; set; }
    }
}