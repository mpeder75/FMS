﻿using FeedbackService.Application.Command.CommandDto;
using FeedbackService.Application.Query.QueryDto;
using FeedbackService.Domain.Entities;

namespace FeedbackService.Application.Query;

public interface IFeedbackpostQuery
{
    Task<FeedbackpostDto> GetFeedbackpost(Guid feedbackpostGuid);
    Task<IEnumerable<FeedbackpostDto>> GetFeedbackposts();
    Task<List<Feedbackpost>> GetFeedbackpostsByRoom(Guid roomId);

}