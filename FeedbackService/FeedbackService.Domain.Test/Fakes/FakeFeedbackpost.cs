using FeedbackService.Domain.Entities;

namespace FeedbackService.Domain.Test.Fakes;

public class FakeFeedbackPost : FeedbackPost
{
    private readonly List<FakeComment> _comments;

    public FakeFeedbackPost(Guid roomId, Guid authorId, string title, string issueText, string solutionText, DateTime createdAt)
    {
        RoomId = roomId;
        AuthorId = authorId;
        Title = title;
        IssueText = issueText;
        SolutionText = solutionText;
        Likes = 0;
        Dislikes = 0;
        CreatedAt = createdAt;
        _comments = new List<FakeComment>();
        RowVersion = new byte[0];
    }

    public new void AssureTitleHaveContent()
    {
        base.AssureTitleHaveContent();
    }

    public new void AssureIssueHaveContent()
    {
        base.AssureIssueHaveContent();
    }

    public new void AssureSolutionHaveContent()
    {
        base.AssureSolutionHaveContent();
    }
}