using FeedbackService.Application;
using FeedbackService.Application.Command;
using FeedbackService.Application.Command.CommandDto;
using FeedbackService.Application.Query;
using FeedbackService.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/feedbackpost", (IFeedbackpostQuery query) => query.GetFeedbackposts());
app.MapGet("/feedbackpost{id}", (Guid id, IFeedbackpostQuery query) => query.GetFeedbackpost(id));
app.MapPost("/feedbackpost", ([FromBody] CreateFeedbackpostDto feedbackpost, [FromServices] IFeedbackpostCommand command) => command.CreateAsync(feedbackpost));
app.MapPut("/feedbackpost{id}", ([FromBody] UpdateFeedbackpostDto feedbackpost, [FromServices] IFeedbackpostCommand command) => command.UpdateAsync(feedbackpost));
app.MapDelete("/feedbackpost{id}", ([FromBody] DeleteFeedbackpostDto feedbackpost, [FromServices] IFeedbackpostCommand command) => command.DeleteAsync(feedbackpost));


app.Run();

