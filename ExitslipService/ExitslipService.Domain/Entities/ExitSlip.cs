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

        public Lesson Lesson { get; set; }

        public Student Student { get; set; }

        public List<Question> Questionnaire { get; set; }

        public bool IsDistributed { get; set; }

        public Comment TeacherComment { get; set; }
    }


    //temp class placeholders.
    public class Lesson
    {
    }

    public class Student
    {
    }

    public class Question
    {
    }

    public class Comment
    {
    }
    //--
}


