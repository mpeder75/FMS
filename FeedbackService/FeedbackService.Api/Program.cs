using FeedbackService.Application;
using FeedbackService.Application.Command;
using FeedbackService.Application.Command.CommandDto;
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


// Endpoints 
app.MapGet("/feedbackpost", (IFeedbackpostQuery query) => query.GetFeedbackposts());
app.MapGet("/feedbackpost{id}", (Guid id, IFeedbackpostQuery query) => query.GetFeedbackpost(id));
app.MapPost("/feedbackpost", ([FromBody]CreateFeedbackpostDto feedbackpost, [FromServices]IFeedbackpostCommand command) => command.CreateAsync(feedbackpost));
app.MapPut("/feedbackpost{id}", ([FromBody] UpdateFeedbackpostDto feedbackpost, [FromServices] IFeedbackpostCommand command) => command.UpdateAsync(feedbackpost));
app.MapDelete("/feedbackpost{id}", ([FromBody] DeleteFeedbackpostDto feedbackpost, [FromServices] IFeedbackpostCommand command) => command.DeleteAsync(feedbackpost));
app.MapGet("/teacher/{teacherId}/feedbackposts", async (Guid teacherId, IFeedbackpostQuery feedbackpostQuery) =>
{
    var feedbackposts = await feedbackpostQuery.GetByTeacherIdAsync(teacherId);
    return Results.Ok(feedbackposts);
});
app.MapPost("/feedbackpost/{id}/comment", async (Guid id, [FromBody] AddFeedbackpostCommentDto addCommentDto, [FromServices] IFeedbackpostCommand command) =>
{
    await command.AddCommentAsync(id, addCommentDto);
    return Results.Ok();
});

app.Run();