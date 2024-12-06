using System.Net.Http.Json;

namespace FakeSmtpServer;

public class EmailSender
{
    private readonly HttpClient _httpClient;

    public EmailSender(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task SendEmailAsync(string toAddress, string message)
    {
        var emailDto = new EmailDto
        {
            ToAddress = toAddress,
            Message = message
        };

        var response = await _httpClient.PostAsJsonAsync("http://apigateway:8080/receive-email", emailDto);
        response.EnsureSuccessStatusCode();
    }
}

public record EmailDto
{
    public string ToAddress { get; init; }
    public string Message { get; init; }
}