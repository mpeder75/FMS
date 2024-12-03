using ExitslipService.Application.Query.QueryDto;
using ExitslipService.Domain.Entities;

namespace ExitslipService.Application.Query.ExitSlipDto
{
    public class ExitSlipReplyDTO
    {
        public Guid PostId { get; set; }
        public Guid LessonId { get; set; }
        public Guid StudentId { get; set; }
        public List<QuestionForm> Questions { get; set; }
        public string TeacherComment { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
