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
        protected ExitSlip(){}

        private ExitSlip(Guid lessonId, Guid studentId, List<Question> questions, bool isDistributed, Comment teacherComment)
        {
            LessonId = lessonId;
            StudentId = studentId;
            Questions = questions;
            IsDistributed = isDistributed;
            TeacherComment = teacherComment;
        }
        private ExitSlip(Guid lessonId, List<Question> questions, bool isDistributed)
        {
            LessonId = lessonId;
            StudentId = Guid.Empty;
            Questions = questions;
            IsDistributed = isDistributed;
            TeacherComment = new Comment();
        }
        public Guid LessonId { get; protected set; }
        public Guid StudentId { get; protected set; }
        public List<Question> Questions { get; protected set; }
        public bool IsDistributed { get; protected set; }
        public Teacher Teacher {  get; protected set; }
        public Comment TeacherComment { get; protected set; }

        public static ExitSlip Create(Guid lessonId, List<Question> questions, bool isDistributed = false)
        {
            var result = new ExitSlip(lessonId, questions, isDistributed);
            return result;
        }

        public void Update(List<Question> questions, Comment teacherComment, Guid studentId)
        {
            this.Questions = questions;
            this.TeacherComment = teacherComment;
            this.StudentId = studentId;
        }

        public void Distribute()
        {
            this.IsDistributed = true;
        }
    }


    public class Question : DomainEntity
    {
    }

    public class Comment : DomainEntity
    {
    }

    public class Teacher : DomainEntity
    {

    }
}


