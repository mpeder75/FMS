using DummyDb.Application.Dto;
using DummyDb.Application.IQueries;
using DummyDb.Infrastructure;
using DummyDb.Infrastructure.ExternalServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddHttpClient(); 
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

// https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-8.0&tabs=visual-studio
app.MapGet("/ping", () => { return Results.Ok("Ping reply"); });
app.MapGet("/SchoolClasses", (ISchoolClassQuery query) => query.GetSchoolClasses());
app.MapGet("/SchoolClasses/{id}", (Guid id, ISchoolClassQuery query) => query.GetSchoolClassById(id));



// Add a route to call this method in your API.
//app.MapGet("/fetch", async (IHttpClientFactory clientFactory) =>
//{
//    var schoolClass = await FMSServiceProxy.FetchSchoolClassAsync(clientFactory);

//    return schoolClass is not null
//        ? Results.Ok(schoolClass)
//        : Results.Problem("Failed to fetch data from the external API.");
//});

app.Run();
