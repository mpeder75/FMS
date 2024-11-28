using FeedbackService.Domain.Entities;

namespace FeedbackService.Domain.DomainServices;

public class FeedbackReportService
{
    public List<Feedbackpost> GetFeedbackPosts(Teacher teacher)
    {
        var feedbackPosts = new List<Feedbackpost>();
        foreach (var schoolClass in teacher.Classes)
        foreach (var room in schoolClass.Rooms)
            feedbackPosts.AddRange(room.Feedbackposts);
        return feedbackPosts;
    }

    public string GenerateFeedbackReport(Teacher teacher)
    {
        var feedbackPosts = GetFeedbackPosts(teacher);
        var report = string.Join("\n", feedbackPosts.Select(fp => fp.Title));
        return report;
    }
}