using FeedbackService.Domain.Entities;
using SharedKernel.Entities;

namespace FeedbackService.Application.Command.CommandDto;

public record UpdateFeedbackpostDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Question Feedback { get; set; }
    public Room Room { get; set; }
    public List<DateTime> EditedTimes { get; set; }
    public List<Comment> Comments { get; set; }
    public List<Question> History { get; set; }
    public byte[] RowVersion { get; set; } = null!;

}