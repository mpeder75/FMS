using FeedbackService.Domain.Entities;

namespace FeedbackService.Application.Command;

public interface IFeedbackpostRepository
{
    public Task AddFeedbackpostAsync(Feedbackpost feedbackpost);
}