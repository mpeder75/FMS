using ExitslipService.Application.Command;
using Microsoft.Extensions.DependencyInjection;

namespace ExitslipService.Application;

public static class ServiceCollectionExtension
{
    //scope into the Api here.
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IExitSlipCommand, ExitSlipCommand>();
        return services;
    }

}
    