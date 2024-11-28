using FeedbackService.Domain.Entities;

namespace FeedbackService.Application;

public interface IFeedbackpostRepository
{
    Task<FeedbackPost> GetFeedbackPostAsync(Guid id);
    Task<List<FeedbackPost>> GetAllAsync();
    Task AddFeedbackPostAsync(FeedbackPost feedbackpost);
    Task AddCommentAsync(Comment comment);
    Task UpdateAsync(FeedbackPost post, byte[] rowversion);
    Task DeleteAsync(Guid postId);
}