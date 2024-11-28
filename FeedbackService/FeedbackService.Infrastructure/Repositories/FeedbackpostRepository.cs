using FeedbackService.Application;
using FeedbackService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeedbackService.Infrastructure.Repositories;

public class FeedbackpostRepository : IFeedbackpostRepository
{
    private readonly FeedbackContext _db;

    public FeedbackpostRepository(FeedbackContext context)
    {
        _db = context;
    }

    async Task<FeedbackPost> IFeedbackpostRepository.GetFeedbackPostAsync(Guid id)
    {
        return await _db.FeedbackPosts.FirstOrDefaultAsync(x => x.Id == id);
    }

    async Task<List<FeedbackPost>> IFeedbackpostRepository.GetAllAsync()
    {
        return await _db.FeedbackPosts.ToListAsync();
    }


    async Task IFeedbackpostRepository.AddFeedbackPostAsync(FeedbackPost feedbackPost)
    {
        await _db.FeedbackPosts.AddAsync(feedbackPost); // "AddAsync" Is primarily beneficial when dealing with a large number of entities, a simple "Add" would be sufficient here
        await _db.SaveChangesAsync();
    }

    async Task IFeedbackpostRepository.AddCommentAsync(Comment comment)
    {
        await _db.Comments.AddAsync(comment);
        await _db.SaveChangesAsync();
    }

    async Task IFeedbackpostRepository.DeleteAsync(Guid postId)
    {
        var feedbackpost = await _db.FeedbackPosts.FirstOrDefaultAsync(x => x.Id == postId);

        if (feedbackpost != null)
        {
            _db.FeedbackPosts.Remove(feedbackpost);
            await _db.SaveChangesAsync();
        }
    }

    async Task IFeedbackpostRepository.UpdateAsync(FeedbackPost post, byte[] rowversion)
    {
        var existingPost = await _db.FeedbackPosts.FirstOrDefaultAsync(x => x.Id == post.Id);
        if (existingPost != null)
        {
            _db.Entry(existingPost).CurrentValues.SetValues(post);
            await _db.SaveChangesAsync();
        }
    }

}