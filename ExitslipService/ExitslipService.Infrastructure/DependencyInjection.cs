using ExitslipService.Application.UnitOfWork;
using ExitSlipService.Infrastructure.OnionDemo.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExitSlipService.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            /*            // Database
                        // https://github.com/dotnet/SqlClient/issues/2239
                        // https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli
                        // Add-Migration InitialMigration -Context BookMyHomeContext -Project OnionDemo.DatabaseMigration
                        // Update-Database -Context BookMyHomeContext -Project OnionDemo.DatabaseMigration
                        services.AddDbContext<ExitSlipContext>(options =>
                            options.UseSqlServer(
                                configuration.GetConnectionString
                                    ("BookMyHomeDbConnection"),
                                x =>
                                    x.MigrationsAssembly("OnionDemo.DatabaseMigration")));

            */
            return services;

        }
    }
}
