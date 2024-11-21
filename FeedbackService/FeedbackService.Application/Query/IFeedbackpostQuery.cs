using FeedbackService.Application.Query.QueryDto;

namespace FeedbackService.Application.Query;

public interface IFeedbackpostQuery
{
    Task<List<FeedbackpostDto>> GetFeedbackpostsByTeacherAsync(Guid teacherId);

}