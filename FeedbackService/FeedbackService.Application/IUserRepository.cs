using FeedbackService.Domain.Entities;

namespace FeedbackService.Application;

public interface IUserRepository
{
    Task<User> GetAsync(Guid id);
}