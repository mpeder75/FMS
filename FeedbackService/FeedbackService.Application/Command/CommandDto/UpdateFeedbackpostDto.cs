using FeedbackService.Domain.Entities;

namespace FeedbackService.Application.Command.CommandDto;

public record UpdateFeedbackpostDto
{
    public Guid Id { get; init; }
    public byte[] RowVersion { get; init; } = null!;
//---------------------------------------------------------------
    public Guid RoomId { get; protected set; }
    public Guid AuthorId { get; protected set; }
    public string Title { get; protected set; }
    public string IssueText { get; protected set; }
    public string SolutionText { get; protected set; }

}