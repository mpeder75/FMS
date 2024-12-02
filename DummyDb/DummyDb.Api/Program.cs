using DummyDb.Application.IQueries;
using DummyDb.Infrastructure;
using DummyDb.Infrastructure.ExternalServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application & Infrastructure services
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapGet("/ping", () => { return Results.Ok("Ping reply"); });
app.MapGet("/CRMData", (ICRMClusterQuery query) => query.GetCluster());
app.MapGet("/SchoolClasses/{id}", (Guid id, ISchoolClassQuery query) => query.GetSchoolClassById(id));

// Test SeedMetode
app.MapPost("/api/feedback/seed", async (IFeedbackProxy feedbackProxy) => await feedbackProxy.SeedData());

app.Run();
