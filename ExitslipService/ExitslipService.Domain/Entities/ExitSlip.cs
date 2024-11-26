using System;
using System.Collections.Generic;
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
        private ExitSlip(Guid lessonId, Teacher author, List<QuestionForm> questions, bool isDistributed)
        {
            LessonId = lessonId;
            StudentId = Guid.Empty;
            _questions = questions;
            IsDistributed = isDistributed;
            TeacherComment = new Comment();
            Teacher = author;
        }
        public Guid LessonId { get; protected set; }
        public Guid StudentId { get; protected set; }
        public IReadOnlyCollection<QuestionForm> Questions => _questions;
        public bool IsDistributed { get; protected set; }
        public Teacher Teacher { get; protected set; }
        public Comment TeacherComment { get; protected set; }

        public static ExitSlip Create(Guid lessonId, Teacher author, List<QuestionForm> questions, bool isDistributed = false)
        {
            var result = new ExitSlip(lessonId, author, questions, isDistributed);
            return result;
        }

        public void Update(List<QuestionForm> questions, Comment teacherComment, Guid studentId)
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
    public class Comment : DomainEntity
    {
        public string Content
        {
            get; protected set;
        }

    }
}


