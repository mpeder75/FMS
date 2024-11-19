using System;
using System.Collections.Generic;
using System.Linq;
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
        public Guid LessonId { get; set; }

        public Guid StudentId { get; set; }

        public List<Question> Questions { get; set; }

        public bool IsDistributed { get; set; }

        public Comment TeacherComment { get; set; }

        public static ExitSlip Create(Guid lessonId, List<Question> questions, bool isDistributed = false)
        {
            var result = new ExitSlip(lessonId, questions, isDistributed);
            return result;
        }
    }




    public class Question : DomainEntity
    {
    }

    public class Comment : DomainEntity
    {
    }


}


