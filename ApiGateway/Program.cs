using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add YARP
builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/receive-email", async ([FromBody] EmailDto emailDto) =>
{
    // Simuler at modtage en e-mail ved at skrive beskeden til konsollen
    Console.WriteLine($"Received email for {emailDto.ToAddress}");
    Console.WriteLine("Message:");
    Console.WriteLine(emailDto.Message);
    return Results.Ok();
});

app.MapReverseProxy();

app.Run();

public record EmailDto
{
    public string ToAddress { get; init; }
    public string Message { get; init; }
}
