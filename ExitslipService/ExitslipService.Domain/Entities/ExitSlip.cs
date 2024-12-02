using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExitslipService.Domain.Entities
{
    public class ExitSlip : DomainEntity
    {
        private List<QuestionForm> _questions;
        protected ExitSlip()
        {
            _questions = new List<QuestionForm>();
        }
        private ExitSlip(Guid lessonId, Guid authorId, List<QuestionForm> questions, bool isDistributed)
        {
            LessonId = lessonId;
            StudentId = Guid.Empty;
            _questions = questions;
            IsDistributed = isDistributed;
            TeacherComment = string.Empty;
            TeacherId = authorId;
        }
        public Guid LessonId { get; protected set; }
        public Guid StudentId { get; protected set; }
        public IReadOnlyCollection<QuestionForm> Questions => _questions;
        public bool IsDistributed { get; protected set; }
        public Guid TeacherId { get; protected set; }
        public string TeacherComment { get; protected set; }

        public static ExitSlip Create(Guid lessonId, Guid authorId, List<QuestionForm> questions, bool isDistributed = false)
        {
            var result = new ExitSlip(lessonId, authorId, questions, isDistributed);
            return result;
        }

        public void Update(List<QuestionForm> questions, string teacherComment, Guid studentId)
        {
            this._questions = questions;
            this.TeacherComment = teacherComment;
            this.StudentId = studentId;
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


