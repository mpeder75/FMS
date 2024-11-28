using FeedbackService.Domain.Entities;

namespace FeedbackService.Domain.Test.Fakes
{
    public class FakeUser : User
    {
        public FakeUser(string firstName, string lastName, string email)
            : base(firstName, lastName, email)
        {
        }
    }
}