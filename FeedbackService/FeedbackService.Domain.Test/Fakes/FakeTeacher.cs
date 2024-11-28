using FeedbackService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackService.Domain.Test.Fakes
{
    public class FakeTeacher : Teacher
    {
        public FakeTeacher(string firstName, string lastName, string email)
            : base(firstName, lastName, email)
        {
        }
    }
}
