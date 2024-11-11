using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FMS.Infrastructure
{
    public static class DependencyInjection
    {
        // Add-Migration InitialMigration -Context FMSContext -Project FMS.DatabaseMigration
        // Update-Database -Context FMSContext -Project FMS.DatabaseMigration
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FMSContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString
                ("LocalConnectionFMS"), x => x.MigrationsAssembly("FMS.DatabaseMigration")));
            return services;
        }
    }
}
