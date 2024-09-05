using BuildingBlocks.Extensions.GuardClauses;

namespace RentOCar.Users.Domain.Entities;

public class User : AggregateRoot<UserId>
{
    public Name Name { get; private set; }

    public Document Document { get; private set; }

    public DateTime BirthDate { get; private set; }

    public Email Email { get; private set; }

    public Address Address { get; private set; }

    private User(
        Name name,
        Document document,
        DateTime birthDate,
        Email email,
        Address address)
    {
        Id = UserId.Of(Guid.NewGuid());
        Name = name;
        Document = document;
        BirthDate = birthDate;
        Email = email;
        Address = address;
    }

    public static User Create(
        Name name,
        Document document,
        DateTime birthDate,
        Email email,
        Address address)
    {
        Guard.Against.Null(name, nameof(name));
        Guard.Against.Null(document, nameof(document));
        Guard.Against.IsMinor(birthDate);
        Guard.Against.IsInFuture(birthDate);
        Guard.Against.ValidEmail(email.Value);
        Guard.Against.Null(address);

        return new User(name, document, birthDate, email, address);
    }

    public void UpdateAddress(Address address)
    {
        Guard.Against.Null(address);
        Address = address;
    }

}
