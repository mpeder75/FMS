using FakeSmtpServer.Dto;
using FakeSmtpServer.Interfaces;
using FakeSmtpServer.MockData;
using FakeSmtpServer.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IEmailSender, EmailSender>(); // Use interface for DI
builder.Services.AddSingleton<IMailList, FakeMailList>(); // Inject mailing list as singleton

var app = builder.Build();

// Configure middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/send-email", async ([FromBody] RoomDto roomDto, IMailList mailingList, IEmailSender emailSender) =>
{
    var teachersToNotify = mailingList.GetTeachersByRoomId(roomDto.RoomId);
    var sentEmails = new List<string>();

    foreach (var teacher in teachersToNotify)
    {
        var message = $"Dear {teacher.FirstName} {teacher.LastName}, there is high activity on feedbackpost made in room: {roomDto.RoomId}";
        await emailSender.SendEmailAsync(teacher.Email, message);
        sentEmails.Add($"Email sent to: {teacher.Email} with message: {message}");
    }

    return Results.Ok(sentEmails);
});

app.Run();