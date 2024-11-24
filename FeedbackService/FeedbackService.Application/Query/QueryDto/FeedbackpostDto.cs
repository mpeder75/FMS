namespace FeedbackService.Application.Query.QueryDto;

public record FeedbackpostDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Feedback { get; set; }
    public int Likes { get; set; }
    public int Dislikes { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<CommentDto> Comments { get; set; }
    public string? Author { get; set; }
}