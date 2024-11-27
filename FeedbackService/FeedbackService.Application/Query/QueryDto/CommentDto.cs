using Microsoft.VisualBasic.CompilerServices;

namespace FeedbackService.Application.Query.QueryDto;

public record CommentDto
{
    public Guid Id { get; init; }
    public string CommentString { get; init; }
    public DateTime CreatedAt { get; init; }
}