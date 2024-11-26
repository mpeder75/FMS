using FeedbackService.Application.Command.CommandDto;
using FeedbackService.Application.UnitOfWork;
using FeedbackService.Domain.Entities;

namespace FeedbackService.Application.Command;

public class FeedbackpostCommand : IFeedbackpostCommand
{
    private readonly IFeedbackpostRepository _feedbackpostRepository;
    private readonly IUserRepository _userRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IUnitOfWork _uow;

    public FeedbackpostCommand(IFeedbackpostRepository feedbackpostRepository, IRoomRepository roomRepository, IUserRepository userRepository, IUnitOfWork uow)
    {
        _feedbackpostRepository = feedbackpostRepository;
        _userRepository = userRepository;
        _roomRepository = roomRepository;
        _uow = uow;
    }

    async Task IFeedbackpostCommand.CreateAsync(CreateFeedbackpostDto createFeedbackpostDto)
    {
        var author = await _userRepository.GetAsync(createFeedbackpostDto.AuthorId);
        var room = await _roomRepository.GetAsync(createFeedbackpostDto.RoomId);
        var feedbackpost = Feedbackpost.Create(author, createFeedbackpostDto.Title, room, createFeedbackpostDto.Question);
        await _feedbackpostRepository.AddAsync(feedbackpost);
    }

    async Task IFeedbackpostCommand.UpdateAsync(UpdateFeedbackpostDto updateFeedbackpostDto)
    {
        try
        {
            _uow.BeginTransaction();

            var feedbackpost = await _feedbackpostRepository.GetAsync(updateFeedbackpostDto.Id);

            feedbackpost.Update(updateFeedbackpostDto.Title, updateFeedbackpostDto.Feedback, updateFeedbackpostDto.Room);

            await _feedbackpostRepository.UpdateAsync(feedbackpost, updateFeedbackpostDto.RowVersion);
            _uow.Commit();
        }
        catch (Exception)
        {
            try
            {
                _uow.Rollback();
            }
            catch (Exception)
            {
                throw new Exception("Error while updating feedbackpost");
            }
            throw;
        }
    }

    async Task IFeedbackpostCommand.DeleteAsync(DeleteFeedbackpostDto deleteFeedbackpostDto)
    {
        try
        {
            _uow.BeginTransaction();
            await _feedbackpostRepository.DeleteAsync(deleteFeedbackpostDto.Id);
            _uow.Commit();
        }
        catch (Exception e)
        {
            try
            {
                _uow.Rollback();
            }
            catch (Exception)
            {
                throw new Exception("Error while deleting feedbackpost");
            }
            throw;
        }
    }
    
    async Task IFeedbackpostCommand.AddCommentAsync(Guid feedbackpostId, AddFeedbackpostCommentDto addCommentDto)
    {
        var author = await _userRepository.GetAsync(addCommentDto.AuthorId);
        var comment = Comment.Create(addCommentDto.CommentString);
        comment.Author = author;
        await _feedbackpostRepository.AddCommentAsync(feedbackpostId, comment);
    }
}