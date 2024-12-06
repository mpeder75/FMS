using ExitslipService.Domain.Entities;

namespace ExitslipService.Application.Command.CommandDto
{
    public record CreateExitSlipPostDTO
    {
        public Guid LessonId { get; set; }
        public List<QuestionDTO> Questionnaire { get; set; }
        public Guid TeacherId { get; internal set; }
    }

}
