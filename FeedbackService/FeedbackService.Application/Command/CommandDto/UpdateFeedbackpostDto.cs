using FeedbackService.Domain.Entities;
using SharedKernel.Entities;

namespace FeedbackService.Application.Command.CommandDto;

public record UpdateFeedbackpostDto
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public Question Feedback { get; init; }
    public Room Room { get; init; }
    public List<DateTime> EditedTimes { get; init; }
    public List<Comment> Comments { get; init; }
    public List<Question> History { get; init; }
    public byte[] RowVersion { get; init; } = null!;

}