using FeedbackService.Domain.Entities;

namespace FeedbackService.Domain.Test.Fakes;

public class FakeUser : User
{
    public FakeUser(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}