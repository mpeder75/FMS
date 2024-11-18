using FeedbackService.Domain.Entities;

namespace FeedbackService.Application;

public interface IFeedbackpostRepository
{
    Task AddFeedbackpostAsync(Feedbackpost feedbackpost);
    void UpdateFeedbackpostAsync(Feedbackpost post, byte[] rowversion);
}