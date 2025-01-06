using FakeSmtpServer.Dto;
using FakeSmtpServer.Interfaces;
using System.Net.Mail;
using System.Net;

namespace FakeSmtpServer.Services;

public class EmailSender : IEmailSender
{
    public async Task SendEmailAsync(string toAddress, string message)
    {
        var smtpClient = new SmtpClient("localhost")
        {
            Port = 1025, // Fake SMTP-serverens port
            EnableSsl = false, // Fake SMTP understøtter ikke SSL
            Credentials = CredentialCache.DefaultNetworkCredentials
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress("noreply@example.com"), // Afsender
            Subject = "Room Activity Notification",
            Body = message,
            IsBodyHtml = false
        };
        mailMessage.To.Add(toAddress);

        // Send e-mailen
        await smtpClient.SendMailAsync(mailMessage);
    }
}