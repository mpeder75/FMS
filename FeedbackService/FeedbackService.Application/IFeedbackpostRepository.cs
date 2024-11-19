using FeedbackService.Domain.Entities;
using SharedKernel.Entities;

namespace FeedbackService.Application;

public interface IFeedbackpostRepository
{
    Task<Feedbackpost> GetAsync(Guid id);
    Task<List<Feedbackpost>> GetFeedbackposts();
    Task<List<Feedbackpost>> GetFeedbackpostsByRoom(Guid roomId);
    Task AddAsync(Feedbackpost feedbackpost);
    Task UpdateAsync(Feedbackpost post, byte[] rowversion);
    Task DeleteAsync(Guid postId);
}