using FeedbackService.Application;
using FeedbackService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeedbackService.Infrastructure.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly FeedbackContext _db;

    public RoomRepository(FeedbackContext context)
    {
        _db = context;
    }
    async Task<Room> IRoomRepository.GetAsync(Guid id)
    {
        return await _db.Rooms.FirstOrDefaultAsync(x => x.Id == id);
    }
}