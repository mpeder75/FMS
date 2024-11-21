namespace FeedbackService.Application.Query.QueryDto;

public record CommentDto
{
    public Guid Id { get; set; }
    public string CommentString { get; set; }
    public DateTime CreatedAt { get; set; }
}