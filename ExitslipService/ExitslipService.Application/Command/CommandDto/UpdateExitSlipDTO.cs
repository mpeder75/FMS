using ExitslipService.Domain.Entities;

namespace ExitslipService.Application.Command.CommandDto;

public record UpdateExitSlipDTO
{
    public Guid Id { get; set; }
    public Guid LessonId { get; set; }
    public Guid StudentId { get; internal set; }
    public Comment TeacherComment { get; internal set; }
    public List<Question> Questions { get; internal set; }
}