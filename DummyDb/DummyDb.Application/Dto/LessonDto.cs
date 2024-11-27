using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyDb.Application.Dto
{
    public class LessonDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public TeacherDto Teacher { get; set; }
        public Guid SchoolClassId { get; set; }
    }
}
