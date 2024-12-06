using FeedbackService.Application;
using FeedbackService.Application.Query;
using FeedbackService.Application.UnitOfWork;
using FeedbackService.Domain.DomainService;
using FeedbackService.Infrastructure.Queries;
using FeedbackService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FeedbackService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IFeedbackPostQuery, FeedbackPostQuery>();
        services.AddScoped<IFeedbackPostRepository, FeedbackPostRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork<FeedbackContext>>();
        services.AddScoped<IFeedbackPostDomainService, FeedbackPostDomainService>(); 

        // Database
        services.AddDbContext<FeedbackContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnectionFeedbackService"),
                x => x.MigrationsAssembly("FeedbackService.DatabaseMigration")));

        services.AddHttpClient();

        return services;
    }
}