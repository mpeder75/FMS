using FeedbackService.Application.Command.CommandDto;

namespace FeedbackService.Application.Command;

public interface IFeedbackpostCommand
{
    void Create(CreateFeedbackpostDto createFeedbackpostDto);
    void Update(UpdateFeedbackpostDto updateFeedbackpostDto);
    void Delete(DeleteFeedbackpostDto deleteFeedbackpostDto);
}