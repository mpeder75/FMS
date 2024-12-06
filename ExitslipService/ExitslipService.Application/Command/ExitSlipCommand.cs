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

    public ExitSlipCommand(IExitSlipRepository repo, IUnitOfWork uow, IExitSlipQuery query)
    {
        _repository = repo;
        _uow = uow;
        _query = query;
    }
    async void IExitSlipCommand.CreatePost(CreateExitSlipPostDTO createExitSlipPostDto)
    {
        //Validate here
        bool IsValid = true;
        if (IsValid)
        {
            //This is for creating the ExitSlip and attaching it to a Lesson; For submission of answers, use Update.
            Guid lessonId = createExitSlipPostDto.LessonId;
            List<QuestionForm> questions = createExitSlipPostDto.Questionnaire
                .Select(dto => new QuestionForm
                {
                    Question = dto.Question,
                    Answer = dto.Answer
                }).ToList();

            Guid teacherId = createExitSlipPostDto.TeacherId;
            var exitSlip = ExitSlipPost.Create(lessonId, teacherId, questions);
            _repository.Add(exitSlip);
        }
    }

    void IExitSlipCommand.CreateReply(CreateExitSlipReplyDTO createExitSlipReplyDto)
    {
        bool IsValid = true;
        if (IsValid)
        {
            Guid postId = createExitSlipReplyDto.PostId;
            Guid lessonId = createExitSlipReplyDto.LessonId;
            Guid studentId = createExitSlipReplyDto.StudentId;
            string comment = createExitSlipReplyDto.Comment;
            List<QuestionForm> questions = createExitSlipReplyDto.Questionnaire
                .Select(dto => new QuestionForm
                {
                    Question = dto.Question,
                    Answer = dto.Answer
                }).ToList();
            var exitSlip = ExitSlipReply.Create(lessonId, postId, studentId, questions, comment);
            _repository.Add(exitSlip);
        }
    }

}