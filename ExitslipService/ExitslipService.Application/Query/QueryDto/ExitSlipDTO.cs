using ExitslipService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExitslipService.Application.Query.ExitSlipDto
{
    public class ExitSlipDTO
    {
        public Guid LessonId { get; set; }
        public Guid StudentId { get; set; }
        public List<QuestionForm> Questions { get; set; }
        public bool IsDistributed { get; set; }
        public Teacher Teacher { get; set; }
        public Comment TeacherComment { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
