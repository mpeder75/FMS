using SharedKernel.Entities;

namespace FeedbackService.Domain.Entities;

public class Feedbackpost : DomainEntity
{
    private readonly List<Comment> _comments;
    private readonly List<DateTime> _editedTimes;
    private readonly List<Question> _history;

    public AbstractUser Author { get; protected set; }
    public string Title { get; protected set; }
    public Question Feedback { get; protected set; }
    public int Likes { get; protected set; }
    public int Dislikes { get; protected set; }
    public Room Room { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public IReadOnlyCollection<DateTime> EditedTimes => _editedTimes;
    public IReadOnlyCollection<Comment> Comments => _comments;
    public IReadOnlyCollection<Question> History => _history;

    protected Feedbackpost(AbstractUser author, string title, Room room, Question feedback)
    {
        Author = author;
        Title = title;
        Room = room;
        Feedback = feedback;
        Likes = 0;
        Dislikes = 0;
        CreatedAt = DateTime.Now;
    }


    public static Feedbackpost Create(Student originalPoster, string title, Room room, Question feedback)
    {
        return new Feedbackpost(originalPoster, title, room, feedback);
    }

    public void Update(string title, Question question, Room room)
    {
        throw new NotImplementedException();
    }

    public void AddComment(string commentString)
    {
        var comment = Comment.Create(commentString);
        _comments.Add(comment);
    }

    public void IncrementLikes()
    {
        Likes++;
    }

    public void DecrementLikes()
    {
        Likes--;
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