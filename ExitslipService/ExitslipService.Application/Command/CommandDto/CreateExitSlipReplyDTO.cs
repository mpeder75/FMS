using ExitslipService.Domain.Entities;

namespace ExitslipService.Application.Command.CommandDto;

public record CreateExitSlipReplyDTO
{
    public Guid PostId { get; set; }
    public Guid LessonId { get; set; }
    public Guid StudentId { get; set; }
    public string Comment { get; set; }
    public List<QuestionDTO> Questionnaire { get; set; }
}