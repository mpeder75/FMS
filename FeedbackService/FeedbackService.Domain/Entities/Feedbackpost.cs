using FeedbackService.Domain.DomainService;
using FeedbackService.Domain.DomainService.DomainServiceDto;

namespace FeedbackService.Domain.Entities;

public class FeedbackPost : DomainEntity
{
    private readonly List<Comment> _comments;

    public Guid RoomId { get; protected set; }
    public Guid AuthorId { get; protected set; }
    public string Title { get; protected set; }
    public string IssueText { get; protected set; }
    public string SolutionText { get; protected set; }
    public int Likes { get; protected set; }
    public int Dislikes { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public IReadOnlyCollection<Comment> Comments => _comments;

    protected FeedbackPost(Guid roomId, Guid authorId, string title, string issueText, string solutionText)
    {
        RoomId = roomId;
        AuthorId = authorId;
        Title = title;
        IssueText = issueText;
        SolutionText = solutionText;
        Likes = 0;
        Dislikes = 0;
        CreatedAt = DateTime.Now;
        _comments = new List<Comment>();
        AssureTitleHaveContent();
        AssureIssueAndSolutionHaveContent();
    }

    public static FeedbackPost Create(Guid roomId, Guid authorId, string title, string issueText, string solutionText)
    {
        return new FeedbackPost(roomId, authorId, title, issueText, solutionText);
    }

    public void Update(string issueText, string solutionText)
    {
        IssueText = issueText;
        SolutionText = solutionText;
        AssureIssueAndSolutionHaveContent();
    }

    public Comment CreateComment(string commentString, Guid authorId)
    {
        var comment = Comment.Create(commentString, authorId);
        _comments.Add(comment);
        return comment;
    }

    protected void AssureTitleHaveContent()
    {
        if (string.IsNullOrWhiteSpace(Title))
            throw new Exception("Add a Title.");
    }

    protected void AssureIssueAndSolutionHaveContent()
    {
        if (string.IsNullOrWhiteSpace(IssueText))
            throw new Exception("Describe an issue.");

        if (string.IsNullOrWhiteSpace(SolutionText))
            throw new Exception("Add a solution.");
    }

    public void IncrementLikes()
    {
        Likes++;
    }

    public async Task IncrementLikesAsync(IFeedbackPostDomainService domainService)
    {
        if (Likes == 20)
        {
            var roomIdDto = new RoomIdDto { RoomId = this.RoomId };
            await domainService.NotifyApiAsync(roomIdDto);
        }
    }
    
    public void IncrementDislikes()
    {
        Dislikes++;
    }

    public void DecrementDislikes()
    {
        Dislikes--;
    }
}