namespace FeedbackService.Application.Command.CommandDto;

public record CreateFeedbackpostDto
{
    public int AuthorId { get; set; }
    public string Title { get; set; }
    public int RoomId { get; set; }

    public Question Question { get; set; }

}