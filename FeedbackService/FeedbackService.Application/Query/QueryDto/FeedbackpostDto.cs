namespace FeedbackService.Application.Query.QueryDto;

public record FeedbackpostDto
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string QuestionText { get; init; }
    public string AnswerText { get; init; }
    public Guid AuthorId { get; init; }
    public Room Room { get; init; }
    public string Feedback { get; init; }
    public int Likes { get; init; }
    public int Dislikes { get; init; }
    public List<DateTime> EditedTimes { get; init; }
    public List<CommentDto> Comments { get; init; }
    public List<QuestionDto> History { get; init; }

    public DateTime CreatedAt { get; init; }
    public string? Author { get; init; }
}