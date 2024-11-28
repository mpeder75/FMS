namespace FeedbackService.Application.Command.CommandDto;

public record CreateFeedbackPostDto
{
    public Guid RoomId { get; set; }
    public Guid AuthorId { get; set; }
    public string Title { get; set; }
    public string IssueText { get; set; }
    public string SolutionText { get; set; }
}