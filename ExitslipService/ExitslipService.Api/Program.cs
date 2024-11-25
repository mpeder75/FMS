using ExitslipService.Application.Command;
using ExitslipService.Application.Command.CommandDto;
using ExitslipService.Application.Interfaces;
using ExitslipService.Application.Query;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
app.MapGet("/teacher/{id}/exitslips", (Guid id, IExitSlipQuery query) => query.GetAllByTeacherId(id));

//GetAll by lesson
app.MapGet("/lesson/{id}/exitslips", (Guid id, IExitSlipQuery query) => query.GetAllByLessonId(id));

//Create ExitSlip with questions and an authoring teacher
app.MapPost("/exitslip", async (CreateExitSlipDTO exitslip, IExitSlipCommand command) => command.Create(exitslip));

//Update ExitSlip with answers and answering student.
app.MapPut("/exitslip", async (UpdateExitSlipDTO exitslip, IExitSlipCommand command) => command.Update(exitslip));


app.Run();
