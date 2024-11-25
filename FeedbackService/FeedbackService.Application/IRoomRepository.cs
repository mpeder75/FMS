using FeedbackService.Domain.Entities;

namespace FeedbackService.Application;

public interface IRoomRepository
{
    Task<Room> GetAsync(Guid id);
}