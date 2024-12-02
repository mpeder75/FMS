using FeedbackService.Domain.Entities;

namespace FeedbackService.Application.Command.CommandDto;

public record UpdateFeedbackpostDto
{
    public Guid Id { get; init; }
    public byte[] RowVersion { get; init; } = null!;
//---------------------------------------------------------------
    public string IssueText { get; set; }
    public string SolutionText { get; set; }

}