using FeedbackService.Application;
using FeedbackService.Application.Command;
using FeedbackService.Application.Command.CommandDto;
using FeedbackService.Application.Query;
using FeedbackService.Domain.Entities;
using FeedbackService.Infrastructure;
using FeedbackService.Infrastructure.Queries;
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

// Endpoints --- FeedbackPost ----
// Create FeedbackPost og Issue, da de ikke kan eksistere uden hinanden:
app.MapPost("/feedbackPost", async ([FromBody] CreateFeedbackPostDto feedbackPostDto, [FromServices] IFeedbackPostCommand command) 
    => await command.CreateAsync(feedbackPostDto));

// Et Query på en liste af FeedbackPosts vil altid være i reletaion til et RoomId:
app.MapGet("/feedbackPost/byRoom/{id}", async (Guid roomId, IFeedbackPostQuery query) 
    => await query.GetFeedbackPostsByRoomAsync(roomId));

// Queries til test:
app.MapGet("/feedbackPosts", async (IFeedbackPostQuery query) 
    => await query.GetFeedbackPostsAsync());
app.MapGet("/feedbackPost/{id}", async (Guid id, IFeedbackPostQuery query) 
    => await query.GetFeedbackPostAsync(id));

// Update og Delete - Dette er funktioner kun Author (UserId) har adgang til:
app.MapPut("/feedbackPost{id}", async ([FromBody] UpdateFeedbackpostDto feedbackpost, [FromServices] IFeedbackPostCommand command) 
    => await command.UpdateAsync(feedbackpost));
app.MapDelete("/feedbackPost{id}", async ([FromBody] DeleteFeedbackpostDto feedbackpost, [FromServices] IFeedbackPostCommand command) 
    => await command.DeleteAsync(feedbackpost));

// Rapport - En filteret list af FeedbackPosts fra et specifikt Room i et given tidsrum (Demo: decending by comment.count).
app.MapGet("/feedbackPost/byRoom/{roomId}/report", async (Guid roomId, DateTime startdate, DateTime endDate, IFeedbackPostQuery query) 
    => await query.GetFeedbackPostsByRoomAndDateAsync(roomId, startdate, endDate));

// Endpoints --- Comment ----
// Create Comment:
app.MapPost("/comment", async (CreateCommentDto commentDto, IFeedbackPostCommand command) 
    => await command.CreateCommentAsync(commentDto));

// Queries -> Skal kunne returner en liste af Comments fra et FeedbackPost: Overflødig?


// Update og Delete - Dette er funktioner kun Author (UserId) har adgang til:

app.Run();