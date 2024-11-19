namespace FeedbackService.Application.Command.CommandDto;

public record DeleteFeedbackpostDto
{
    public Guid Id { get; set; }
    public byte[] RowVersion { get; set; } = null!;
}