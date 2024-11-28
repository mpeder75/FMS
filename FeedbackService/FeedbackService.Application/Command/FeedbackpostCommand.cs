using FeedbackService.Application.Command.CommandDto;
using FeedbackService.Application.UnitOfWork;
using FeedbackService.Domain.Entities;

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

    async Task IFeedbackpostCommand.CreateAsync(CreateFeedbackPostDto feedbackPostDto)
    {
        // Load
        // Do
        var feedbackpost = FeedbackPost.Create(feedbackPostDto.RoomId, feedbackPostDto.AuthorId, feedbackPostDto.Title, feedbackPostDto.IssueText, feedbackPostDto.SolutionText);
        // Save
        await _feedbackpostRepository.AddFeedbackPostAsync(feedbackpost);
    }

    async Task IFeedbackpostCommand.UpdateAsync(UpdateFeedbackpostDto updateFeedbackpostDto)
    {
        try
        {
            _uow.BeginTransaction();

            var feedbackpost = await _feedbackpostRepository.GetFeedbackPostAsync(updateFeedbackpostDto.Id);
            
            //feedbackpost.Update(updateFeedbackpostDto.Title, updateFeedbackpostDto.Feedback, updateFeedbackpostDto.Room);

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

    async Task IFeedbackpostCommand.CreateCommentAsync(CreateCommentDto commentDto)
    {
        try
        {
            _uow.BeginTransaction();
            // Load
            FeedbackPost feedbackPost = await _feedbackpostRepository.GetFeedbackPostAsync(commentDto.FeedbackPostId);
            // Do
            var comment = feedbackPost.CreateComment(commentDto.CommentString, commentDto.AuthorId);
            // Save
            await _feedbackpostRepository.AddCommentAsync(comment);
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
                throw new Exception($"Rollback failed: {e.Message}", e);
            }
            throw;
        }
    }
}