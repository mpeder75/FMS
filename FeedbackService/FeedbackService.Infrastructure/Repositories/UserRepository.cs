using FeedbackService.Application;
using FeedbackService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeedbackService.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FeedbackContext _db;

    public UserRepository(FeedbackContext context)
    {
        _db = context;
    }

    async Task<User> IUserRepository.GetAsync(Guid id)
    {

        var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (user != null)
        {
            return user;
        }
        else
        {
            throw new Exception("User not found");
        }
    }
}