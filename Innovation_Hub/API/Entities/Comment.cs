using System;

namespace API.Entities
{
    public class Comment
    {
        public DateTime Date { get; set; }
        public int VotesCount { get; set; }
        public bool Anonymous { get; set; }
    }
}