using ExitslipService.Application.Command;
using ExitslipService.Application.Query;
using Microsoft.Extensions.DependencyInjection;

namespace ExitslipService.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IExitSlipCommand, ExitSlipCommand>();
        return services;
    }

}
    