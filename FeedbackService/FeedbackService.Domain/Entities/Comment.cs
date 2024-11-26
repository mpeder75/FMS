using FeedbackService.Domain;

public class Comment : DomainEntity
{
    public string CommentString { get; set; }
    public DateTime CreatedAt { get; set; }

    protected Comment()
    {
    }

    private Comment(string commentString)
    {
        CommentString = commentString;
        CreatedAt = DateTime.Now;
    }

    public static Comment Create(string commentString)
    {
        return new Comment(commentString);
    }
}