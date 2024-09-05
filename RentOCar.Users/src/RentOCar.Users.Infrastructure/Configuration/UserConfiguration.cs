using Microsoft.EntityFrameworkCore.Metadata.Builders;

using RentOCar.Users.Domain.ValueObjects;

namespace RentOCar.Users.Infrastructure.Configuration;

public class UserConfiguration :IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .HasConversion(
                userId => userId.Value,
                dbId => UserId.Of(dbId));

        builder.Property()
    }
}
