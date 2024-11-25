using Microsoft.Extensions.DependencyInjection;
using FeedbackService.Application.Command;

namespace FeedbackService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IFeedbackpostCommand, FeedbackpostCommand>();
        return services;
    }
}
