using ExitslipService.Application;
using ExitslipService.Application.Command;
using ExitslipService.Application.Command.CommandDto;
using ExitslipService.Application.Query;
using ExitSlipService.Infrastructure;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddHttpClient();

var app = builder.Build();

//purpose is to service the ExitSlip object for all intents and purposes and have endpoints to make said services' output retrievable.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseHttpsRedirection();

//GetAll/Update -> En student skal kunne tilgå alle sine Exitslips og kunne ændre i dem:

//GetAll by student
app.MapGet("/student/{id}/exitslips", async (Guid id, IExitSlipQuery query) => await query.GetAllByStudentId(id));

//GetAll by lesson
app.MapGet("/lesson/{id}/exitslips", async (Guid id, IExitSlipQuery query) => await query.GetAllByLessonId(id));


//CreatePost ExitSlip with questions in relation to a specific LessonId - Det er kun Teacher som har adgang til denne funktion.
app.MapPost("/exitslip/post", async ([FromBody]CreateExitSlipPostDTO exitslip,[FromServices] IExitSlipCommand command) => command.CreatePost(exitslip));

//Update ExitSlip with answers and answering student. - Kun adgang for Students.
app.MapPost("/exitslip/reply", async ([FromBody]CreateExitSlipReplyDTO exitslip,[FromServices] IExitSlipCommand command) => command.CreateReply(exitslip));


app.Run();