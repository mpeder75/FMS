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

app.MapPost("/send-email", async ([FromBody] RoomIdDto roomIdDto) =>
{
    var teachersToNotify = mailingList.GetTeachersByRoomId(roomIdDto.RoomId);
    foreach (var teacher in teachersToNotify)
    {
        var message = $"Dear {teacher.FirstName} {teacher.LastName},\n\n" +
                      $"There is high activity on feedbackpost made in room: {roomIdDto.RoomId}";
        
        await emailSender.SendEmailAsync(teacher.Email, message);
    }
    return Results.Ok();
});

app.Run();

public record RoomIdDto
{
    public Guid RoomId { get; init; }
}