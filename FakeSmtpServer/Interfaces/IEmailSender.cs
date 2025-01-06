namespace FakeSmtpServer.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string toAddress, string message);
    }
}
