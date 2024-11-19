using ExitslipService.Application.Command.CommandDto;
using ExitslipService.Application.Interfaces;
using ExitslipService.Application.UnitOfWork;
using ExitslipService.Domain.Entities;

namespace ExitslipService.Application.Command;

public class ExitSlipCommand : IExitSlipCommand
{
    private readonly IUnitOfWork _uow;
    private readonly IExitSlipRepository _repository;

    public ExitSlipCommand(IExitSlipRepository repo,  IUnitOfWork uow)
    {
        _repository = repo;
        _uow = uow;
    }
    async void IExitSlipCommand.Create(CreateDTO createExitSlipDto)
    {
        //Validate here
        bool IsValid = true;
        if (IsValid)
        {
            //This is for creating the ExitSlip and attaching it to a Lesson; For submission of answers, use Update.
            Guid lessonId = createExitSlipDto.LessonId; 
            List<Question> questions = createExitSlipDto.Questions;
            var exitSlip = ExitSlip.Create(lessonId, questions);
            _repository.Add(exitSlip);
        }
    }

    async void IExitSlipCommand.Update(UpdateDTO updateExitSlipDto)
    {
        //load ExitSlip by Id, grab StudentId, answers and teacherComment, update the ExitSlip with UoW oversight.
        ExitSlip.Update();
    }
}