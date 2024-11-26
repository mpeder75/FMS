namespace FeedbackService.Application.Command.CommandDto;

public record AddFeedbackpostCommentDto
{
    public Guid AuthorId { get; init; }
    public string CommentString { get; init; }
}

