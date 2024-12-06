using FeedbackService.Application.Query.QueryDto;
using FeedbackService.Application.Query;
using FeedbackService.Infrastructure.Queries;
using FeedbackService.Infrastructure;

namespace FeedbackService.Domain.Test.Fakes
{
    public class FakeFeedbackPostQuery : FeedbackPostQuery
    {
        public FakeFeedbackPostQuery(FeedbackContext dbContext) : base(dbContext)
        {
        }

        // Expose the base implementation for testing
        public async Task<IEnumerable<FeedbackPostDto>> TestGetFeedbackPostsByRoomAndDateAsync(Guid roomId, DateOnly startDate, DateOnly endDate)
        {
            return await ((IFeedbackPostQuery)this).GetFeedbackPostsByRoomAndDateAsync(roomId, startDate, endDate);
        }
    }


    // ---------- IFeedbackPostQuery -------------
    //Task<FeedbackPost> GetFeedbackPostAsync(Guid feedbackpostGuid);
    //Task<IEnumerable<FeedbackPost>> GetFeedbackPostsAsync();
    //Task<IEnumerable<FeedbackPost>> GetFeedbackPostsByRoomAsync(Guid roomId);
    //Task<IEnumerable<FeedbackPost>> GetFeedbackPostsByRoomAndDateAsync(Guid roomId, DateOnly startDate, DateOnly endDate);
}
