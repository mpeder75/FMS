using FeedbackService.Domain.Entities;

namespace FeedbackService.Domain.Test.Fakes
{
    public class FakeSchoolClass : SchoolClass
    {
        public FakeSchoolClass(int term, Teacher teacher)
            : base(term, teacher)
        {
        }
    }
}