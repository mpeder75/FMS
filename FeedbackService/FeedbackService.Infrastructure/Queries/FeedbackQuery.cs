using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FeedbackService.Application.Query;
using FeedbackService.Application.Query.QueryDto;
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

        async Task<FeedbackpostDto> IFeedbackpostQuery.GetFeedbackpost(Guid feedbackpostGuid)
        {
            var post = await _db.Feedbackposts
                                .Include(a => a.Author)
                                .Include(b => b.Feedback)
                                .Include(c => c.Room)
                                .Include(d => d.EditedTimes)
                                .Include(e => e.Comments)
                                .Include(f => f.History)
                                .FirstOrDefaultAsync(fp => fp.Id == feedbackpostGuid);

            if (post == null)
            {
                return new FeedbackpostDto();
            }

            return new FeedbackpostDto
            {
                Id = post.Id,
                Title = post.Title,
                QuestionText = post.Feedback.QuestionText,
                AnswerText = post.Feedback.AnswerText,
                Author = post.Author.Name, // Assuming User has a property Name
                Room = post.Room,
                Likes = post.Likes,
                Dislikes = post.Dislikes,
                CreatedAt = post.CreatedAt,
                EditedTimes = post.EditedTimes.ToList(),
                Comments = post.Comments.Select(c => new CommentDto
                {
                    CommentString = c.CommentString,
                    // Map other properties if needed
                }).ToList(),
                History = post.History.Select(h => new QuestionDto
                {
                    QuestionText = h.QuestionText
                    // Map other properties if needed
                }).ToList()
            };
        }

        async Task<IEnumerable<FeedbackpostDto>> IFeedbackpostQuery.GetFeedbackposts()
        {
            throw new NotImplementedException();
        }
    }
}
