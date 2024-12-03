using FeedbackService.Application;
using FeedbackService.Application.Command;
using FeedbackService.Application.Command.CommandDto;
using FeedbackService.Application.Query;
using FeedbackService.Domain.DomainService.DomainServiceDto;
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

//app.UseHttpsRedirection();

// Endpoints --- FeedbackPost ----
// Create FeedbackPost og Issue, da de ikke kan eksistere uden hinanden:
app.MapPost("/feedbackPost",
    async ([FromBody] CreateFeedbackPostDto feedbackPostDto, [FromServices] IFeedbackPostCommand command) =>
    await command.CreateAsync(feedbackPostDto));

// Et Query på en liste af FeedbackPosts vil altid være i reletaion til et RoomId:
app.MapGet("/feedbackPost/byRoom/{id}",
    async (Guid roomId, IFeedbackPostQuery query) => await query.GetFeedbackPostsByRoomAsync(roomId));

//// Queries til test:
app.MapGet("/feedbackPosts", async (IFeedbackPostQuery query) => await query.GetFeedbackPostsAsync());
app.MapGet("/feedbackPost/{id}", async (Guid id, IFeedbackPostQuery query) => await query.GetFeedbackPostAsync(id));

//// Update og Delete - Dette er funktioner kun Author (UserId) har adgang til:
app.MapPut("/feedbackPost{id}",
    ([FromBody] UpdateFeedbackpostDto feedbackpost, [FromServices] IFeedbackPostCommand command) =>
        command.UpdateAsync(feedbackpost));
app.MapDelete("/feedbackPost{id}",
    ([FromBody] DeleteFeedbackpostDto feedbackpost, [FromServices] IFeedbackPostCommand command) =>
        command.DeleteAsync(feedbackpost));

//// Rapporten? - Der er en filteret list af FeedbackPost fra et specifikt Room?
//app.MapGet("/teacher/{teacherId}/feedbackposts", async (Guid teacherId, IFeedbackPostQuery feedbackpostQuery) =>
//{
//    var feedbackposts = await feedbackpostQuery.GetByTeacherIdAsync(teacherId);
//    return Results.Ok(feedbackposts);
//});

// Endpoints --- Comment ----
// Create Comment:
app.MapPost("/comment",
    async (CreateCommentDto commentDto, IFeedbackPostCommand command) => await command.CreateCommentAsync(commentDto));
// endpoint der sender RoomId til Fake email SMTP Server
app.MapPost("/notify", async (RoomIdDto roomIdDto) =>
{
    // Here you would handle the notification and send RoomId to the external project
    // For now, we will just simulate this with a console output
    Console.WriteLine($"RoomId {roomIdDto.RoomId} has been notified.");
    return Results.Ok();
});

app.Run();