using FeedbackService.Domain.Entities;

namespace FeedbackService.Domain.Test.Fakes;

public class FakeFeedbackpost : Feedbackpost
{
    public FakeFeedbackpost(User author, string title, Room room, Question feedback)
        : base(author, title, room, feedback)
    {
    }

    public new void Anonymize()
    {
        base.Anonymize();
    }

    public new void Update(string title, Question question, Room room)
    {
        base.Update(title, question, room);
    }

    public new void AddComment(string commentString)
    {
        base.AddComment(commentString);
    }

    public new void IncrementLikes()
    {
        base.IncrementLikes();
    }

    public new void DecrementLikes()
    {
        base.DecrementLikes();
    }

    public new void IncrementDislikes()
    {
        base.IncrementDislikes();
    }

    public new void DecrementDislikes()
    {
        base.DecrementDislikes();
    }
}