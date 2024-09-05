using Microsoft.EntityFrameworkCore.Metadata.Builders;

using RentOCar.Users.Domain.ValueObjects;

namespace RentOCar.Users.Infrastructure.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .HasConversion(
                userId => userId.Value,
                dbId => UserId.Of(dbId));

        builder.ComplexProperty(
            u => u.Name,
            nameBuilder =>
            {
                nameBuilder.Property(n => n.FirstName)
                    .HasColumnName(nameof(Name.FirstName))
                    .HasMaxLength(50)
                    .IsRequired();

                nameBuilder.Property(n => n.LastName)
                    .HasColumnName(nameof(Name.LastName))
                    .HasMaxLength(50)
                    .IsRequired();
            });

        builder.ComplexProperty(
            u => u.Document,
            documentBuilder =>
            {
                documentBuilder.Property(d => d.Value)
                    .HasColumnName(nameof(User.Document))
                    .HasMaxLength(14)
                    .IsRequired();
            });

        builder.ComplexProperty(
            u => u.Email,
            mailBuilder =>
            {
                mailBuilder.Property(m => m.Value)
                    .HasMaxLength(50)
                    .IsRequired();
            });

        builder.Property(u => u.BirthDate)
            .IsRequired();

        builder.ComplexProperty(
            u => u.Address,
            addressBuilder =>
            {
                addressBuilder.Property(a => a.Street)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(a => a.Number)
                    .HasMaxLength(6)
                    .IsRequired();

                addressBuilder.Property(a => a.City)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(a => a.State)
                    .HasMaxLength(15)
                    .IsRequired();

                addressBuilder.Property(a => a.Country)
                    .HasMaxLength(25)
                    .IsRequired();

                addressBuilder.Property(a => a.ZipCode)
                    .HasMaxLength(10)
                    .IsRequired();
            });
    }
}
