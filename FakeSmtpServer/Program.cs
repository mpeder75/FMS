using FakeSmtpServer;
using FakeSmtpServer.FakeMalingList;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<EmailSender>(); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var mailingList = new FakeMalingList();
var emailSender = app.Services.GetRequiredService<EmailSender>();


// [frombody] deserializer JSON payload til et RoomIdDto objekt
app.MapPost("/send-email", async ([FromBody] RoomIdDto roomIdDto) =>
{
    var teachersToNotify = mailingList.GetTeachersByRoomId(roomIdDto.RoomId);
    var sentEmails = new List<string>();

    foreach (var teacher in teachersToNotify)
    {
        var message = $"Dear {teacher.FirstName} {teacher.LastName}, there is high activity on feedbackpost made in room: {roomIdDto.RoomId}";
        
        await emailSender.SendEmailAsync(teacher.Email, message);
        sentEmails.Add($"Email sent to: {teacher.Email} with message: {message}");
    }

    return Results.Ok(sentEmails);
});

app.Run();

public record RoomIdDto
{
    public Guid RoomId { get; init; }
}