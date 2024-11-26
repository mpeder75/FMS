using FeedbackService.Application.Command.CommandDto;

namespace FeedbackService.Application.Command;

public interface IFeedbackpostCommand
{
    Task CreateAsync(CreateFeedbackpostDto createFeedbackpostDto);
    Task UpdateAsync(UpdateFeedbackpostDto updateFeedbackpostDto);
    Task DeleteAsync(DeleteFeedbackpostDto deleteFeedbackpostDto);
    Task AddCommentAsync(Guid feedbackpostId, AddFeedbackpostCommentDto addCommentDto);
}