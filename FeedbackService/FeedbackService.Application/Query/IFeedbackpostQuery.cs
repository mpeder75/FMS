using FeedbackService.Application.Command.CommandDto;
using FeedbackService.Application.Query.QueryDto;

namespace FeedbackService.Application.Query;

public interface IFeedbackpostQuery
{
    Task<FeedbackpostDto> GetFeedbackpost(Guid feedbackpostGuid);
    Task<IEnumerable<FeedbackpostDto>> GetFeedbackposts();
}