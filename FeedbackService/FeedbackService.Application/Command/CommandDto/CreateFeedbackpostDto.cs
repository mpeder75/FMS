using FeedbackService.Domain.Entities;

namespace FeedbackService.Application.Command.CommandDto;

public record CreateFeedbackpostDto
{
    public Guid AuthorId { get; init; }
    public string Title { get; init; }
    public Guid RoomId { get; init; }

    public Question Question { get; init; }

}