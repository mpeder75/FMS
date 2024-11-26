using FeedbackService.Application.Query.QueryDto;

namespace FeedbackService.Application.Query;

public interface IFeedbackpostQuery
{
    Task<FeedbackpostDto> GetFeedbackpost(Guid feedbackpostGuid);
    Task<IEnumerable<FeedbackpostDto>> GetFeedbackposts();
    Task<List<FeedbackpostDto>> GetFeedbackpostsByRoom(Guid roomId);
    Task<List<FeedbackpostDto>> GetByTeacherIdAsync(Guid teacherId);
}