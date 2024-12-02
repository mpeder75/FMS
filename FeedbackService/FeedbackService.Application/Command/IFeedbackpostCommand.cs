﻿using FeedbackService.Application.Command.CommandDto;

namespace FeedbackService.Application.Command;

public interface IFeedbackPostCommand
{
    Task CreateAsync(CreateFeedbackPostDto createFeedbackpostDto);
    Task UpdateAsync(UpdateFeedbackpostDto updateFeedbackpostDto);
    Task DeleteAsync(DeleteFeedbackpostDto deleteFeedbackpostDto);
    Task CreateCommentAsync(CreateCommentDto createCommentDto);
}