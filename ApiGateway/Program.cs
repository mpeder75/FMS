using System.Security.Claims;
using ApiGateway.Database;
using ApiGateway.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddScoped<UserManager<AppUser>>();
builder.Services.AddDbContext<IdentityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionGateway")));

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 1;
    options.Password.RequiredUniqueChars = 1;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    options.User.RequireUniqueEmail = false;
});

builder.Services
    .AddIdentityApiEndpoints<AppUser>()
    .AddEntityFrameworkStores<IdentityDbContext>();

// Add YARP
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("userPolicy", policy =>
        policy.RequireAuthenticatedUser());

    options.AddPolicy("adminPolicy", policy =>
        policy.RequireClaim("IsAdmin"));

    options.AddPolicy("RequiresTeacher", policy =>
        policy.RequireClaim("IsTeacher"));

    options.AddPolicy("RequiresStudent", policy =>
        policy.RequireClaim("IsStudent"));

    options.AddPolicy("RequiresKasten", policy =>
        policy.RequireClaim("IsKasten"));
});

builder.Services.AddHttpClient(); // Add HttpClient factory

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/receive-email", async ([FromBody] EmailDto emailDto) =>
{
    // Simulate receiving an email by writing the message to the console
    Console.WriteLine($"Received email for {emailDto.ToAddress}");
    Console.WriteLine("Message:");
    Console.WriteLine(emailDto.Message);
    return Results.Ok();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapGroup("/account").MapIdentityApi<AppUser>();

app.MapPost("/addClaimToUser",
     [Authorize(Policy = "userPolicy")]
async (string userId, string claimType, string claimValue, UserManager<AppUser> userManager) =>
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null) return Results.NotFound("User not found");

        var claim = new Claim(claimType, claimValue);
        var result = await userManager.AddClaimAsync(user, claim);

        if (result.Succeeded)
            return Results.Ok("Claim added successfully");
        return Results.BadRequest(result.Errors);
    });
/*
// New endpoints based on appsettings.json
app.MapGet("/lesson/{id}/exitslips",
    [Authorize(Policy = "RequiresTeacher")]
async (HttpContext httpContext) =>
    {
        var client = httpContext.RequestServices.GetRequiredService<IHttpClientFactory>().CreateClient();
        var response = await client.GetAsync($"http://exitslipservice.api:8080{httpContext.Request.Path}");
        return Results.StatusCode((int)response.StatusCode);
    });

app.MapGet("/student/{id}/exitslips",
    [Authorize(Policy = "RequiresStudent")]
async (HttpContext httpContext) =>
    {
        var client = httpContext.RequestServices.GetRequiredService<IHttpClientFactory>().CreateClient();
        var response = await client.PostAsync($"http://exitslipservice.api:8080{httpContext.Request.Path}", new StreamContent(httpContext.Request.Body));
        return Results.StatusCode((int)response.StatusCode);
    });

app.MapPost("/exitslip/post",
    [Authorize(Policy = "RequiresTeacher")]
async (HttpContext httpContext) =>
    {
        var client = httpContext.RequestServices.GetRequiredService<IHttpClientFactory>().CreateClient();
        var response = await client.PostAsync("http://exitslipservice.api:8080/exitslip/post", new StreamContent(httpContext.Request.Body));
        return Results.StatusCode((int)response.StatusCode);
    });

app.MapPost("/exitslip/reply",
    [Authorize(Policy = "RequiresStudent")]
async (HttpContext httpContext) =>
    {
        var client = httpContext.RequestServices.GetRequiredService<IHttpClientFactory>().CreateClient();
        var response = await client.PostAsync("http://exitslipservice.api:8080/exitslip/reply", new StreamContent(httpContext.Request.Body));
        return Results.StatusCode((int)response.StatusCode);
    });

app.MapPost("/feedbackPost",
    [Authorize(Policy = "userPolicy")]
async (HttpContext httpContext) =>
    {
        var client = httpContext.RequestServices.GetRequiredService<IHttpClientFactory>().CreateClient();
        var response = await client.PostAsync("http://feedbackservice.api:8080/feedbackPost", new StreamContent(httpContext.Request.Body));
        return Results.StatusCode((int)response.StatusCode);
    });

app.MapGet("/feedbackPost/byRoom/{id}",
    [Authorize(Policy = "userPolicy")]
async (HttpContext httpContext) =>
    {
        var client = httpContext.RequestServices.GetRequiredService<IHttpClientFactory>().CreateClient();
        var response = await client.GetAsync($"http://feedbackservice.api:8080{httpContext.Request.Path}");
        return Results.StatusCode((int)response.StatusCode);
    });

app.MapGet("/feedbackPosts",
    [Authorize(Policy = "userPolicy")]
async (HttpContext httpContext) =>
    {
        var client = httpContext.RequestServices.GetRequiredService<IHttpClientFactory>().CreateClient();
        var response = await client.GetAsync("http://feedbackservice.api:8080/feedbackPosts");
        return Results.StatusCode((int)response.StatusCode);
    });

app.MapGet("/feedbackPost/{id}",
    [Authorize(Policy = "userPolicy")]
async (HttpContext httpContext) =>
    {
        var client = httpContext.RequestServices.GetRequiredService<IHttpClientFactory>().CreateClient();
        var response = await client.GetAsync($"http://feedbackservice.api:8080{httpContext.Request.Path}");
        return Results.StatusCode((int)response.StatusCode);
    });

app.MapPut("/feedbackPost/{id}",
    [Authorize(Policy = "userPolicy")]
async (HttpContext httpContext) =>
    {
        var client = httpContext.RequestServices.GetRequiredService<IHttpClientFactory>().CreateClient();
        var response = await client.PutAsync($"http://feedbackservice.api:8080{httpContext.Request.Path}", new StreamContent(httpContext.Request.Body));
        return Results.StatusCode((int)response.StatusCode);
    });

app.MapDelete("/feedbackPost/{id}",
    [Authorize(Policy = "adminPolicy")]
async (HttpContext httpContext) =>
    {
        var client = httpContext.RequestServices.GetRequiredService<IHttpClientFactory>().CreateClient();
        var response = await client.DeleteAsync($"http://feedbackservice.api:8080{httpContext.Request.Path}");
        return Results.StatusCode((int)response.StatusCode);
    });

app.MapPost("/feedbackPost/byRoom/{roomId}/report",
    [Authorize(Policy = "RequiresTeacher")]
async (HttpContext httpContext) =>
    {
        var client = httpContext.RequestServices.GetRequiredService<IHttpClientFactory>().CreateClient();
        var response = await client.PostAsync($"http://feedbackservice.api:8080{httpContext.Request.Path}", new StreamContent(httpContext.Request.Body));
        return Results.StatusCode((int)response.StatusCode);
    });

app.MapPost("/comment",
    [Authorize(Policy = "userPolicy")]
async (HttpContext httpContext) =>
    {
        var client = httpContext.RequestServices.GetRequiredService<IHttpClientFactory>().CreateClient();
        var response = await client.PostAsync("http://feedbackservice.api:8080/comment", new StreamContent(httpContext.Request.Body));
        return Results.StatusCode((int)response.StatusCode);
    });

app.MapPost("/send-email",
    [Authorize(Policy = "RequiresTeacher")]
async (HttpContext httpContext) =>
    {
        var client = httpContext.RequestServices.GetRequiredService<IHttpClientFactory>().CreateClient();
        var response = await client.PostAsync("http://fakesmtpserver:8080/send-email", new StreamContent(httpContext.Request.Body));
        return Results.StatusCode((int)response.StatusCode);
    });
*/

app.MapReverseProxy();
app.Run();

internal record ClaimDto(string Type, string Value);

public record EmailDto
{
    public string ToAddress { get; init; }
    public string Message { get; init; }
}
