using FeedbackService.Application.Query.QueryDto;

namespace FeedbackService.Application.Query;

public interface IFeedbackpostQuery
{
    Task<List<FeedbackpostDto>> GetByTeacherIdAsync(Guid teacherId);
}