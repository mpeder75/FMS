using Microsoft.VisualBasic.CompilerServices;

namespace FeedbackService.Application.Query.QueryDto;

public record CommentDto
{
    public string CommentString { get; init; }
}