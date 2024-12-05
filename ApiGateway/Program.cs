using ApiGateway.Database;
using ApiGateway.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authorization;
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
            new string[] {}
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
    .AddIdentityApiEndpoints<AppUser>() //Gude linje
    .AddEntityFrameworkStores<IdentityDbContext>(); //Gude linje
                                                    //.AddDefaultTokenProviders();


//builder.Services.AddAuthorization();

// Add YARP
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));


builder.Services.AddAuthorization(options =>
{
    /*options.AddPolicy("userPolicy", policy =>
        policy.RequireAuthenticatedUser());*/

    options.AddPolicy("adminPolicy", policy =>
        policy.RequireClaim("ClaimTypes.Role"));

    options.AddPolicy("RequiresTeacher", policy =>
        policy.RequireClaim("IsTeacher"));

    options.AddPolicy("RequiresStudent", policy =>
        policy.RequireClaim("Student"));

    options.AddPolicy("RequiresKasten", policy =>
        policy.RequireClaim("IsKasten"));
});



/*var key = Encoding.ASCII.GetBytes("VerySecretKey");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "fms",
        ValidAudience = "fms",
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});
*/




var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication();
app.UseAuthorization();

app.MapGroup("/account").MapIdentityApi<AppUser>(); //Gude linje



app.MapPost("/addClaimToUser",
    [Authorize(Policy = "RequiresKasten")]
async (string userId, string claimType, string claimValue, UserManager<AppUser> userManager) =>
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return Results.NotFound("User not found");
        }

        var claim = new Claim(claimType, claimValue);
        var result = await userManager.AddClaimAsync(user, claim);

        if (result.Succeeded)
        {
            return Results.Ok("Claim added successfully");
        }
        else
        {
            return Results.BadRequest(result.Errors);
        }
    });



// YARP as a reverse proxy
app.MapReverseProxy();
app.Run();


internal record ClaimDto(string Type, string Value);