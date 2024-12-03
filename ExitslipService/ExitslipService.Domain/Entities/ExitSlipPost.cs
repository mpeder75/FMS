using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExitslipService.Domain.Entities
{
    public class ExitSlipPost : DomainEntity
    {
        private List<QuestionForm> _questionnaire;
        protected ExitSlipPost()
        {
            _questionnaire = new List<QuestionForm>();
        }
        private ExitSlipPost(Guid lessonId, Guid authorId, List<QuestionForm> questions, bool isDistributed)
        {
            LessonId = lessonId;
            TeacherId = authorId;
            _questionnaire = questions;
            IsDistributed = isDistributed;
        }
        public Guid LessonId { get; protected set; }
        public IReadOnlyCollection<QuestionForm> Questionnaire => _questionnaire;
        public bool IsDistributed { get; protected set; }
        public Guid TeacherId { get; protected set; }
        public string TeacherComment { get; protected set; }

        public static ExitSlipPost Create(Guid lessonId, Guid authorId, List<QuestionForm> questions, bool isDistributed = false)
        {
            var result = new ExitSlipPost(lessonId, authorId, questions, isDistributed);
            return result;
        }

        public void Update(List<QuestionForm> questions, string teacherComment, Guid studentId)
        {
            this._questionnaire = questions;
            this.TeacherComment = teacherComment;
        }

        public void Distribute()
        {
            this.IsDistributed = true;
        }
    }
    public class QuestionForm : DomainEntity
    {
        public string Question { get; protected set; }
        public string Answer { get; protected set; }
    }
}


