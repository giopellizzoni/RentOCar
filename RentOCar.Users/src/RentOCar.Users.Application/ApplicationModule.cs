using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

using RentOCar.Users.Infrastructure.Repositories;

namespace RentOCar.Users.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediator()
            .AddDependencyInjection();

        return services;
    }

    private static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(
            config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

        return services;
    }

    private static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
