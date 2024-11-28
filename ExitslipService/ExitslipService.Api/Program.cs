using ExitslipService.Application;
using ExitslipService.Application.Command;
using ExitslipService.Application.Command.CommandDto;
using ExitslipService.Application.Interfaces;
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

app.UseHttpsRedirection();

//GetAll by teacher
app.MapGet("/teacher/{id}/exitslips", async (Guid id, IExitSlipQuery query) => await query.GetAllByTeacherId(id));

//GetAll by lesson
app.MapGet("/lesson/{id}/exitslips", async (Guid id, IExitSlipQuery query) => await query.GetAllByLessonId(id));

//Create ExitSlip with questions and an authoring teacher
app.MapPost("/exitslip", async ([FromBody]CreateExitSlipDTO exitslip,[FromServices] IExitSlipCommand command) => command.Create(exitslip));

//Update ExitSlip with answers and answering student.
app.MapPut("/exitslip", async ([FromBody]UpdateExitSlipDTO exitslip,[FromServices] IExitSlipCommand command) => command.Update(exitslip));

app.Run();
