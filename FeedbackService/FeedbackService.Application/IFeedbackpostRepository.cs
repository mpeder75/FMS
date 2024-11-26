using FeedbackService.Domain.Entities;

namespace FeedbackService.Application;

public interface IFeedbackpostRepository
{
    Task<Feedbackpost> GetAsync(Guid id);
    Task<List<Feedbackpost>> GetAllAsync();
    Task AddAsync(Feedbackpost feedbackpost);
    Task UpdateAsync(Feedbackpost post, byte[] rowversion);
    Task DeleteAsync(Guid postId);
}