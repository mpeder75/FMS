namespace FeedbackService.Application.Command.CommandDto;

public record CreateFeedbackpostDto
{
    public int AuthorId { get; init; }
    public string Title { get; init; }
    public int RoomId { get; init; }

    public Question Question { get; init; }

}