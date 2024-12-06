using FeedbackService.Domain;

public class Comment : DomainEntity
{
    public string CommentString { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public Guid AuthorId { get; protected set; }

    protected Comment(string commentString, Guid authorId)
    {
        CommentString = commentString;
        CreatedAt = DateTime.Now;
        AuthorId = authorId;
    }

    public static Comment Create(string commentString, Guid authorId)
    {
        return new Comment(commentString, authorId);
    }

    public void Update()
    {
        throw new NotImplementedException();
    }

    public void Delete()
    {
        throw new NotImplementedException();
    }
}