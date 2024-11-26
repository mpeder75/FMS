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

    async Task<Feedbackpost> IFeedbackpostRepository.GetAsync(Guid id)
    {
        return await _db.Feedbackposts.FirstOrDefaultAsync(x => x.Id == id);
    }

    async Task<List<Feedbackpost>> IFeedbackpostRepository.GetAllAsync()
    {
        return await _db.Feedbackposts.ToListAsync();
    }
   

    async Task IFeedbackpostRepository.AddAsync(Feedbackpost feedbackpost)
    {
        await _db.Feedbackposts.AddAsync(feedbackpost);
        await _db.SaveChangesAsync();
    }

    async Task IFeedbackpostRepository.DeleteAsync(Guid postId)
    {
        var feedbackpost = await _db.Feedbackposts.FirstOrDefaultAsync(x => x.Id == postId);

        if (feedbackpost != null)
        {
            _db.Feedbackposts.Remove(feedbackpost);
            await _db.SaveChangesAsync();
        }
    }

    async Task IFeedbackpostRepository.UpdateAsync(Feedbackpost post, byte[] rowversion)
    {
        var existingPost = await _db.Feedbackposts.FirstOrDefaultAsync(x => x.Id == post.Id);
        if (existingPost != null)
        {
            _db.Entry(existingPost).CurrentValues.SetValues(post);
            await _db.SaveChangesAsync();
        }
    }

    public async Task AddCommentAsync(Guid feedbackpostId, Comment comment)
    {
        var feedbackpost = await ((IFeedbackpostRepository)this).GetAsync(feedbackpostId);
        if (feedbackpost != null)
        {
            feedbackpost.AddComment(comment.CommentString);
            await _db.SaveChangesAsync();
        }
    }

}