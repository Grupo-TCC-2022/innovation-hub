namespace innovation_hub.Models
{
    public class AppUserCommentVote
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int AppUserId { get; set; }
        public bool Voted { get; set; }
    }
}