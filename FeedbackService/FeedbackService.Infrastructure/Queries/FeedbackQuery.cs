using FeedbackService.Application.Query;
using FeedbackService.Application.Query.QueryDto;
using FeedbackService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeedbackService.Infrastructure.Queries;

public class FeedbackPostQuery : IFeedbackPostQuery
{
    private readonly FeedbackContext _db;

    public FeedbackPostQuery(FeedbackContext db)
    {
        _db = db;
    }

    async Task<FeedbackPostDto> IFeedbackPostQuery.GetFeedbackPostAsync(Guid feedbackPostId)
    {
        var feedbackPost = await _db.FeedbackPosts.AsNoTracking()
        .Include(fp => fp.Comments)
        .SingleAsync(x => x.Id == feedbackPostId);
        return new FeedbackPostDto()
        {
            Id = feedbackPost.Id,
            RoomId = feedbackPost.RoomId,
            AuthorId = feedbackPost.AuthorId,
            Title = feedbackPost.Title,
            IssueText = feedbackPost.IssueText,
            SolutionText = feedbackPost.SolutionText,
            Likes = feedbackPost.Likes,
            Dislikes = feedbackPost.Dislikes,
            CreatedAt = feedbackPost.CreatedAt,
            Comments = feedbackPost.Comments.Select(c => new CommentDto
            {
                Id = c.Id,
                CommentString = c.CommentString,
                CreatedAt = c.CreatedAt,
                AuthorId = c.AuthorId
            }).ToList()
        };
    }

    async Task<IEnumerable<FeedbackPostDto>> IFeedbackPostQuery.GetFeedbackPostsAsync()
    {
        var feedbackPosts = await _db.FeedbackPosts.AsNoTracking()
        .Include(fp => fp.Comments)
        .Select(x => new FeedbackPostDto
        {
            Id = x.Id,
            RoomId = x.RoomId,
            AuthorId = x.AuthorId,
            Title = x.Title,
            IssueText = x.IssueText,
            SolutionText = x.SolutionText,
            Likes = x.Likes,
            Dislikes = x.Dislikes,
            CreatedAt = x.CreatedAt,
            Comments = x.Comments.Select(c => new CommentDto
            {
                Id = c.Id,
                CommentString = c.CommentString,
                CreatedAt = c.CreatedAt,
                AuthorId = c.AuthorId
            }).ToList()
        })
        .ToListAsync();
        return feedbackPosts;
    }

    async Task<IEnumerable<FeedbackPostDto>> IFeedbackPostQuery.GetFeedbackPostsByRoomAsync(Guid roomId)
    {
        var feedbackPosts = await _db.FeedbackPosts.AsNoTracking()
        .Where(x => x.RoomId == roomId)
        .Include(fp => fp.Comments)
        .Select(x => new FeedbackPostDto
        {
            Id = x.Id,
            RoomId = x.RoomId,
            AuthorId = x.AuthorId,
            Title = x.Title,
            IssueText = x.IssueText,
            SolutionText = x.SolutionText,
            Likes = x.Likes,
            Dislikes = x.Dislikes,
            CreatedAt = x.CreatedAt,
            Comments = x.Comments.Select(c => new CommentDto
            {
                Id = c.Id,
                CommentString = c.CommentString,
                CreatedAt = c.CreatedAt,
                AuthorId = c.AuthorId
            }).ToList()
        })
        .ToListAsync();
        return feedbackPosts;
    }


    //public async Task<List<FeedbackPostDto>> GetByTeacherIdAsync(Guid teacherId)
    //{
    //    var feedbackposts = await _db.FeedbackPosts
    //        .Include(fp => fp.Comments)
    //        .Include(fp => fp.Room)
    //        .ThenInclude(r => r.Lessons)
    //        .Where(fp => fp.Room.Lessons.Any(l => l.Teacher.Id == teacherId))
    //        .ToListAsync();

    //    return feedbackposts.Select(fp => new FeedbackPostDto
    //    {
    //        Id = fp.Id,
    //        Title = fp.Title,
    //        Feedback = fp.Feedback.ToString(),
    //        Likes = fp.Likes,
    //        Dislikes = fp.Dislikes,
    //        CreatedAt = fp.CreatedAt,
    //        Author = null, // Anonymize the author
    //        Comments = fp.Comments.Select(c => new CommentDto
    //        {
    //            Id = c.Id,
    //            CommentString = c.CommentString,
    //            CreatedAt = c.CreatedAt
    //        }).ToList()
    //    }).ToList();
    //}
}