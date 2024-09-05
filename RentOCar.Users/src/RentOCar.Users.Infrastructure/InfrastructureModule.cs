using Microsoft.Extensions.DependencyInjection;

using RentOCar.Users.Infrastructure.Context;

namespace RentOCar.Users.Infrastructure;

public static class InfrastructureModule
{

    public static IServiceCollection AddInfrastructutre(this IServiceCollection services)
    {
        services.AddDbContext<UsersDbContext>();
        return services;
    }


}
