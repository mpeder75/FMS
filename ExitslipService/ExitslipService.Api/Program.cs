using ExitslipService.Application.Interfaces;

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
app.MapGet("/teacher/{id}/exitslips", (Guid id, IExitSlipQuery query => query.GetByTeacher(id));

//GetAll by lesson
app.MapGet("/lesson/{id}/exitslips", (Guid id, IExitSlipQuery query => query.GetByLesson(id));

//Create ExitSlip
//app.MapPost

//Update ExitSlip
//app.MapPut

//


app.Run();
