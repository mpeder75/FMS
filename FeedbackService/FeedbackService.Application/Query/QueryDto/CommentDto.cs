using Microsoft.VisualBasic.CompilerServices;

namespace FeedbackService.Application.Query.QueryDto;

public class CommentDto
{
    public Guid Id { get; init; }
    //---------------------------------------------------
    public string CommentString { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid AuthorId { get; set; }
}