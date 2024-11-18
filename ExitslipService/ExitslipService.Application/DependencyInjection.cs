namespace ExitslipService.Application;

public static class ServiceCollectionExtension
{
    //scope into the Api here.
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAccommodationCommand, AccommodationCommand>();
        services.AddScoped<IReviewCommand, ReviewCommand>();
        return services;
    }

}
    