using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExitSlipService.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

                        // Database
                        // https://github.com/dotnet/SqlClient/issues/2239
                        // https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli
                        // Add-Migration InitialMigration -Context BookMyHomeContext -Project OnionDemo.DatabaseMigration
                        // Update-Database -Context BookMyHomeContext -Project OnionDemo.DatabaseMigration
                        services.AddDbContext<ExitSlipContext>(options =>
                            options.UseSqlServer(
                                configuration.GetConnectionString
                                    ("ExitSlipDbConnection"),
                                x =>
                                    x.MigrationsAssembly("ExitslipService.DatabaseMigration")));

            
            return services;
        }
    }
}
