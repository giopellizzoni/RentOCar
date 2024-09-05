using System.Reflection;

namespace RentOCar.Users.Infrastructure.Context;

public class UsersDbContext: DbContext
{

    public UsersDbContext(DbContextOptions<UsersDbContext> options): base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
