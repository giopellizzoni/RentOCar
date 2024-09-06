using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using RentOCar.Users.Infrastructure.Context;

namespace RentOCar.Users.Infrastructure;

public static class InfrastructureModule
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("UsersDb");

        services.AddDbContext<UsersDbContext>(
            options =>
            {
                options.UseSqlServer(connectionString);
            });
        return services;
    }


}
