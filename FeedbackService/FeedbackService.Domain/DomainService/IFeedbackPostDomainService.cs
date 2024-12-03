using FeedbackService.Domain.DomainService.DomainServiceDto;
using FeedbackService.Domain.Entities;

namespace FeedbackService.Domain.DomainService
{
    public interface IFeedbackPostDomainService
    {
        Task NotifyApiAsync(RoomIdDto roomIdDto);
    }
}