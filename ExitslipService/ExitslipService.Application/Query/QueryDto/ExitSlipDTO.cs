using ExitslipService.Application.Query.QueryDto;

namespace ExitslipService.Application.Query.ExitSlipDto
{
    public class ExitSlipDTO
    {
        public Guid LessonId { get; set; }
        public Guid StudentId { get; set; }
        public List<QuestionFormDTO> Questions { get; set; }
        public bool IsDistributed { get; set; }
        public Guid TeacherId { get; set; }
        public string TeacherComment { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
