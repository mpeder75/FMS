using CRMSyncService.Application.IQueries.Dto;
using CRMSyncService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient(); 
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

// Add a route to call this method in your API.
app.MapGet("/fetch", async (IHttpClientFactory clientFactory) =>
{
    var schoolClass = await FetchSchoolClassAsync(clientFactory);

    //return schoolClass is not null
    //    ? Results.Ok(schoolClass)
    //    : Results.Problem("Failed to fetch data from the external API.");
});

app.Run();






async Task<List<SchoolClassDto>> FetchSchoolClassAsync(IHttpClientFactory clientFactory)
{
    var client = clientFactory.CreateClient();

    // Send a GET request
    var response = await client.GetAsync("https://run.mocky.io/v3/66695b6d-dcf5-4117-973b-824d6d907898");

    if (response.IsSuccessStatusCode)
    {
        // Deserialize the response body to a SchoolClassDto
        var schoolClasses = await response.Content.ReadFromJsonAsync<List<SchoolClassDto>>();
        return schoolClasses;
    }

    // Return null if the request failed
    return null;
}