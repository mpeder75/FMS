using FeedbackService.Application.Command.CommandDto;
using FeedbackService.Application.UnitOfWork;
using FeedbackService.Domain.Entities;

namespace FeedbackService.Application.Command;

public class FeedbackPostCommand : IFeedbackPostCommand
{
    private readonly IFeedbackPostRepository _feedbackPostRepository;
    private readonly IUnitOfWork _uow;

    public FeedbackPostCommand(IFeedbackPostRepository feedbackpostRepository, IUnitOfWork uow)
    {
        _feedbackPostRepository = feedbackpostRepository;
        _uow = uow;
    }

    async Task IFeedbackPostCommand.CreateAsync(CreateFeedbackPostDto feedbackPostDto)
    {
        // Load
        // Do
        var feedbackpost = FeedbackPost.Create(feedbackPostDto.RoomId, feedbackPostDto.AuthorId, feedbackPostDto.Title, feedbackPostDto.IssueText, feedbackPostDto.SolutionText);
        // Save
        await _feedbackPostRepository.AddFeedbackPostAsync(feedbackpost);
    }

    async Task IFeedbackPostCommand.UpdateAsync(UpdateFeedbackpostDto updateFeedbackPostDto)
    {
        try
        {
            _uow.BeginTransaction();
            // Load
            var feedbackpost = await _feedbackPostRepository.GetFeedbackPostAsync(updateFeedbackPostDto.Id);
            var rowVersion = _uow.ConvertHexToByteArray(updateFeedbackPostDto.RowVersion);
            // Do
            feedbackpost.Update(updateFeedbackPostDto.IssueText, updateFeedbackPostDto.SolutionText);
            // Save
            await _feedbackPostRepository.UpdateAsync(feedbackpost, rowVersion);
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
                throw new Exception($"Rollback failed while updating: {e.Message}", e);
            }
            throw;
        }
    }

    async Task IFeedbackPostCommand.DeleteAsync(DeleteFeedbackpostDto deleteFeedbackpostDto)
    {
        try
        {
            _uow.BeginTransaction();
            // Load
            // Do & Save
            await _feedbackPostRepository.DeleteAsync(deleteFeedbackpostDto.Id);
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
                throw new Exception($"Rollback failed while deleting: {e.Message}", e);
            }
            throw;
        }
    }

    async Task IFeedbackPostCommand.CreateCommentAsync(CreateCommentDto commentDto)
    {
        try
        {
            _uow.BeginTransaction();
            // Load
            FeedbackPost feedbackPost = await _feedbackPostRepository.GetFeedbackPostAsync(commentDto.FeedbackPostId);
            // Do
            var comment = feedbackPost.CreateComment(commentDto.CommentString, commentDto.AuthorId);
            // Save
            await _feedbackPostRepository.AddCommentAsync(comment);
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
                throw new Exception($"Rollback failed while trying to add a Comment: {e.Message}", e);
            }
            throw;
        }
    }
}