using FeedbackService.Application.Query.QueryDto;

namespace FeedbackService.Application.Query;

public interface IFeedbackPostQuery
{
    Task<FeedbackPostDto> GetFeedbackPostAsync(Guid feedbackpostGuid);
    Task<IEnumerable<FeedbackPostDto>> GetFeedbackPostsAsync();
    Task<IEnumerable<FeedbackPostDto>> GetFeedbackPostsByRoomAsync(Guid roomId);
    //Task<List<FeedbackPostDto>> GetByTeacherIdAsync(Guid teacherId);
}