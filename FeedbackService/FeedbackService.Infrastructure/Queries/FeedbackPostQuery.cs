﻿using FeedbackService.Application.Query;
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

    async Task<Application.Query.QueryDto.FeedbackPostDto> IFeedbackPostQuery.GetFeedbackPostAsync(Guid feedbackPostId)
    {
        var feedbackPost = await _db.FeedbackPosts.AsNoTracking()
        .Include(fp => fp.Comments)
        .FirstOrDefaultAsync(x => x.Id == feedbackPostId);
        return new Application.Query.QueryDto.FeedbackPostDto()
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

    async Task<IEnumerable<Application.Query.QueryDto.FeedbackPostDto>> IFeedbackPostQuery.GetFeedbackPostsAsync()
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

    async Task<IEnumerable<Application.Query.QueryDto.FeedbackPostDto>> IFeedbackPostQuery.GetFeedbackPostsByRoomAsync(Guid roomId)
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

    async Task<IEnumerable<Application.Query.QueryDto.FeedbackPostDto>> IFeedbackPostQuery.GetFeedbackPostsByRoomAndDateAsync(Guid roomId, DateOnly startDate, DateOnly endDate)
    {
        var start = startDate.ToDateTime(TimeOnly.MinValue); 
        var end = endDate.ToDateTime(TimeOnly.MaxValue);

        var feedbackPosts = await _db.FeedbackPosts.AsNoTracking()
        .Where(x => x.RoomId == roomId && x.CreatedAt >= start && x.CreatedAt <= end)
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
        .OrderByDescending(fp => fp.Comments.Count) // This line is only for demo.
        .ToListAsync();
        return feedbackPosts;
    }
}