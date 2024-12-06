using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExitslipService.Domain.Entities
{
    public class ExitSlipReply : DomainEntity
    {
        private List<QuestionForm> _questionnaire;
        protected ExitSlipReply()
        {
            _questionnaire = new List<QuestionForm>();
        }
        private ExitSlipReply(Guid lessonId, Guid postId, Guid studentId, List<QuestionForm> questions, string comment)
        {
            LessonId = lessonId;
            PostId = postId;
            StudentId = studentId;
            _questionnaire = questions;
        }   
        public Guid PostId { get; protected set; }
        public Guid StudentId { get; protected set; }
        public Guid LessonId { get; protected set; }
        public List<QuestionForm> Questionnaire { get; protected set; }
        public string? Comment { get; protected set; }

        public static ExitSlipReply Create(Guid lessonId, Guid postId, Guid studentId, List<QuestionForm> questions, string comment)
        {
            var result = new ExitSlipReply(lessonId, postId, studentId, questions, comment);
            return result;
        }
    }
}
