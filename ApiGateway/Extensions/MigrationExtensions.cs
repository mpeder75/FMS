using ApiGateway.Database;

namespace ApiGateway.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using IdentityDbContext context = scope.ServiceProvider.GetRequiredService<IdentityDbContext>();

        //context.Database.Migrate();
    }
}