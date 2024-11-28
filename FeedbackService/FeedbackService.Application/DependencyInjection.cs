using FeedbackService.Application.Command;
using FeedbackService.Domain.DomainServices;
using Microsoft.Extensions.DependencyInjection;

namespace FeedbackService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register application services here
            services.AddScoped<IFeedbackpostCommand, FeedbackpostCommand>();
            services.AddScoped<FeedbackReportService>();

            return services;
        }
    }
}