using System;

namespace API.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public int VotesCount { get; set; }
        public bool Anonymous { get; set; }
        public MemberDto CommentOwner { get; set; }
    }
}