using FeedbackService.Application;
using FeedbackService.Application.Query;
using FeedbackService.Infrastructure.Queries;
using FeedbackService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FeedbackService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Register query implementations
            services.AddScoped<IFeedbackpostQuery, FeedbackpostQuery>();
            services.AddScoped<IFeedbackpostRepository, FeedbackpostRepository>();

            // Database
            services.AddDbContext<FeedbackContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("FeedbackDbConnection"),
                    x => x.MigrationsAssembly("FeedbackService.DatabaseMigration")));

            return services;
        }
    }
}