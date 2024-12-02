namespace FeedbackService.Application.Command.CommandDto
{
    public class CreateCommentDto
    {
        public string CommentString { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid AuthorId { get; set; }
        public Guid FeedbackPostId { get; set; }
    }
}
