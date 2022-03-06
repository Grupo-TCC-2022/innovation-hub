using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Comments")]
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public DateTime Date { get; set; }
        public int VotesCount { get; set; }
        public bool Anonymous { get; set; }
    }
}