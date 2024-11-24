using FeedbackService.Application;
using FeedbackService.Application.Query;
using FeedbackService.Infrastructure;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// GetFeedbackByTeacherId endpoint
app.MapGet("/teacher/{teacherId}/feedbackposts", async (Guid teacherId, IFeedbackpostQuery feedbackpostQuery) =>
{
    var feedbackposts = await feedbackpostQuery.GetByTeacherIdAsync(teacherId);

    // Anonymize the feedback posts
    foreach (var feedbackpost in feedbackposts)
    {
        feedbackpost.Author = null;
    }
    return Results.Ok(feedbackposts);
});

app.Run();