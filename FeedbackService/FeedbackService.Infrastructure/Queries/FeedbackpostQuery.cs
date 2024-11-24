using FeedbackService.Application.Query;
using FeedbackService.Application.Query.QueryDto;
using FeedbackService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeedbackService.Infrastructure.Queries
{
    public class FeedbackpostQuery : IFeedbackpostQuery
    {
        private readonly FeedbackContext _db;

        public FeedbackpostQuery(FeedbackContext db)
        {
            _db = db;
        }

        public async Task<List<FeedbackpostDto>> GetByTeacherIdAsync(Guid teacherId)
        {
            var feedbackposts = await _db.Feedbackposts
                .Include(fp => fp.Comments)
                .Include(fp => fp.Room)
                .ThenInclude(r => r.Lessons)
                .Where(fp => fp.Room.Lessons.Any(l => l.Teacher.Id == teacherId))
                .ToListAsync();

            return feedbackposts.Select(fp => new FeedbackpostDto
            {
                Id = fp.Id,
                Title = fp.Title,
                Feedback = fp.Feedback.ToString(),
                Likes = fp.Likes,
                Dislikes = fp.Dislikes,
                CreatedAt = fp.CreatedAt,
                Author = null, // Anonymize the author
                Comments = fp.Comments.Select(c => new CommentDto
                {
                    Id = c.Id,
                    CommentString = c.CommentString,
                    CreatedAt = c.CreatedAt
                }).ToList()
            }).ToList();
        }
    }
}