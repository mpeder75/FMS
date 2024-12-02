using FeedbackService.Application;
using FeedbackService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeedbackService.Infrastructure.Repositories;

public class FeedbackPostRepository : IFeedbackPostRepository
{
    private readonly FeedbackContext _db;

    public FeedbackPostRepository(FeedbackContext context)
    {
        _db = context;
    }

    async Task<bool> IFeedbackPostRepository.ExistsAsync(Guid id)
    {
        return await _db.Set<FeedbackPost>().AnyAsync(p => p.Id == id);
    }

    async Task<FeedbackPost> IFeedbackPostRepository.GetFeedbackPostAsync(Guid id)
    {
        return await _db.FeedbackPosts
            .Include(fp => fp.Comments)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    async Task<List<FeedbackPost>> IFeedbackPostRepository.GetAllAsync()
    {
        return await _db.FeedbackPosts.ToListAsync();
    }

    async Task IFeedbackPostRepository.AddFeedbackPostAsync(FeedbackPost feedbackPost)
    {
        await _db.FeedbackPosts.AddAsync(feedbackPost); // "AddAsync" Is primarily beneficial when dealing with a large number of entities, a simple "Add" would be sufficient here
        await _db.SaveChangesAsync();
    }

    async Task IFeedbackPostRepository.AddCommentAsync(Comment comment)
    {
        await _db.Comments.AddAsync(comment);
        await _db.SaveChangesAsync();
    }

    async Task IFeedbackPostRepository.DeleteAsync(Guid id)
    {
        var feedbackPost = await _db.FeedbackPosts
            .Include(fp => fp.Comments)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (feedbackPost == null)
        {
            throw new KeyNotFoundException($"Feedback post with ID {id} not found.");
        }

        _db.Set<Comment>().RemoveRange(feedbackPost.Comments);
        _db.Set<FeedbackPost>().Remove(feedbackPost);
        await _db.SaveChangesAsync();
    }

    async Task IFeedbackPostRepository.UpdateAsync(FeedbackPost post, byte[] rowversion)
    {
        var existingPost = await _db.FeedbackPosts.FirstOrDefaultAsync(x => x.Id == post.Id);
        if (existingPost != null)
        {
            _db.Entry(existingPost).CurrentValues.SetValues(post);
            await _db.SaveChangesAsync();
        }
    }
}