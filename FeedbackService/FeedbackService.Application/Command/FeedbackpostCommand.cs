using FeedbackService.Application.Command.CommandDto;
using FeedbackService.Application.UnitOfWork;

namespace FeedbackService.Application.Command;

public class FeedbackpostCommand : IFeedbackpostCommand
{
    private readonly IFeedbackpostRepository _feedbackpostRepository;
    private readonly IUnitOfWork _uow;

    public FeedbackpostCommand(IFeedbackpostRepository feedbackpostRepository, IUnitOfWork uow)
    {
        _feedbackpostRepository = feedbackpostRepository;
        _uow = uow;
    }

    void IFeedbackpostCommand.Create(CreateFeedbackpostDto createFeedbackpostDto)
    {
        var feedbackpost = _feedbackpostRepository.Get(createFeedbackpostDto.Id);
        
    }

    void IFeedbackpostCommand.Delete(DeleteFeedbackpostDto deleteFeedbackpostDto)
    {
        throw new NotImplementedException();
    }

    void IFeedbackpostCommand.Update(UpdateFeedbackpostDto updateFeedbackpostDto)
    {
        throw new NotImplementedException();
    }
}