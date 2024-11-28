namespace FeedbackService.Application.Query.QueryDto;

public record FeedbackPostDto
{
    public Guid Id { get; init; }
    //---------------------------------------------------
    public Guid RoomId { get; set; }
    public Guid AuthorId { get; set; }
    public string Title { get; set; }
    public string IssueText { get; set; }
    public string SolutionText { get; set; }
    public int Likes { get; set; }
    public int Dislikes { get; set; }
    public DateTime CreatedAt { get; set; }
    public IReadOnlyCollection<CommentDto> Comments { get; init; } = new List<CommentDto>();
}