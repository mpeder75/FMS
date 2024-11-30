using Microsoft.EntityFrameworkCore;
using FeedbackService.Application;
using FeedbackService.Application.Query;
using FeedbackService.Application.UnitOfWork;
using FeedbackService.Infrastructure.Queries;
using FeedbackService.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FeedbackService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFeedbackPostQuery, FeedbackPostQuery>();
            services.AddScoped<IFeedbackPostRepository, FeedbackpostRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork<FeedbackContext>>();


            // Database
            services.AddDbContext<FeedbackContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnectionFeedbackService"),
                    x => x.MigrationsAssembly("FeedbackService.DatabaseMigration")));

            return services;
        }
    }
}