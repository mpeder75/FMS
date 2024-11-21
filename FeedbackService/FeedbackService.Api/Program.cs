using FeedbackService.Application;
using FeedbackService.Application.Query;
using FeedbackService.Infrastructure;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application and Infrastructure services
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

// Example endpoint
app.MapGet("/hello", () => "Hello World");

// Add your endpoints here
app.MapGet("/teacher/{teacherId}/feedbackposts", async (Guid teacherId, IFeedbackpostQuery query) =>
{
    var feedbackposts = await query.GetFeedbackpostsByTeacherAsync(teacherId);
    return Results.Ok(feedbackposts);
});

app.Run();