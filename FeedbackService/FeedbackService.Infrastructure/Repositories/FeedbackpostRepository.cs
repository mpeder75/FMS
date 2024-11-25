using FeedbackService.Application;
using FeedbackService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeedbackService.Infrastructure.Repositories;

internal class FeedbackpostRepository : IFeedbackpostRepository
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

    public async Task<List<Feedbackpost>> GetByTeacherIdAsync(Guid teacherId)
    {
        return await _db.Feedbackposts
            .Include(fp => fp.Student)
            .ThenInclude(s => s.SchoolClass)
            .ThenInclude(sc => sc.Teacher)
            .Where(fp => fp.Student.SchoolClass.Teacher.Id == teacherId)
            .ToListAsync();
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

        async Task<List<Feedbackpost>> IFeedbackpostRepository.GetFeedbackpostsByRoom(Guid roomId)
        {
            return await _db.Feedbackposts.Where(x => x.Room.Id == roomId).ToListAsync();
        }
    }
}
