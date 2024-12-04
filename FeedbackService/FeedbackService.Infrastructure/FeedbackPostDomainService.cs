using System.Net.Http.Json;
using FeedbackService.Domain.DomainService;
using FeedbackService.Domain.DomainService.DomainServiceDto;

namespace FeedbackService.Infrastructure;

public class FeedbackPostDomainService : IFeedbackPostDomainService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public FeedbackPostDomainService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task NotifyApiAsync(RoomIdDto roomIdDto)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.PostAsJsonAsync("http://fakesmtpserver:8080/send-email", roomIdDto);
        response.EnsureSuccessStatusCode();
    }
}