using ExitslipService.Application.Command.CommandDto;
using ExitslipService.Application.Interfaces;
using ExitslipService.Application.Query;
using ExitslipService.Application.UnitOfWork;
using ExitslipService.Domain.Entities;

namespace ExitslipService.Application.Command;

public class ExitSlipCommand : IExitSlipCommand
{
    private readonly IUnitOfWork _uow;
    private readonly IExitSlipRepository _repository;
    private readonly IExitSlipQuery _query;

    public ExitSlipCommand(IExitSlipRepository repo,  IUnitOfWork uow, IExitSlipQuery query)
    {
        _repository = repo;
        _uow = uow;
        _query = query;
    }
    async void IExitSlipCommand.Create(CreateExitSlipDTO createExitSlipDto)
    {
        //Validate here
        bool IsValid = true;
        if (IsValid)
        {
            //This is for creating the ExitSlip and attaching it to a Lesson; For submission of answers, use Update.
            Guid lessonId = createExitSlipDto.LessonId; 
            List<QuestionForm> questions = createExitSlipDto.Questions;
            Teacher author = createExitSlipDto.Teacher;
            var exitSlip =  ExitSlip.Create(lessonId, author, questions);

            _repository.Add(exitSlip);
        }
    }

    async void IExitSlipCommand.Update(UpdateExitSlipDTO updateExitSlipDto)
    {
        //load ExitSlip by Id, grab StudentId, answers and teacherComment, update the ExitSlip with UoW oversight.
        try
        {
            _uow.BeginTransaction();

            ExitSlip exitSlip = await _query.GetOneById(updateExitSlipDto.Id);
            exitSlip.Update(updateExitSlipDto.Questions, updateExitSlipDto.TeacherComment, updateExitSlipDto.StudentId);

            var rowVersion = _uow.ConvertHexToByteArray(updateExitSlipDto.RowVersion);
            _repository.Update(exitSlip, exitSlip.RowVersion);

            _uow.Commit();
        }
        catch (Exception e)
        {
            try
            {
                _uow.Rollback();
            }
            catch (Exception ex)
            {
                throw new Exception($"Rollback failed! {ex.Message}", e);
            }

            throw;
        }
    }

}