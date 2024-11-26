using ExitslipService.Domain.Entities;

namespace ExitslipService.Application.Command.CommandDto;

public record UpdateExitSlipDTO
{
    public Guid Id { get; set; }
    public Guid LessonId { get; set; }
    public Guid StudentId { get; set; }
    public Comment TeacherComment { get; set; }
    public List<QuestionForm> Questions { get; set; }

    public string RowVersion { get; set; }
}