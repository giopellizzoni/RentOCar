namespace RentOCar.Users.Domain.Entities;

public class User : AggregateRoot<UserId>
{
    public string Name { get; private set; }

    public string Document { get; private set; }

    public DateTime BirthDate { get; private set; }

    public Email Email { get; private set; }

    public Address Address { get; private set; }

    private User(
        UserId id,
        string name,
        string document,
        DateTime birthDate,
        Email email,
        Address address)
    {
        Id = id;
        Name = name;
        Document = document;
        BirthDate = birthDate;
        Email = email;
        Address = address;
    }

    public static User Create(
        UserId id,
        string name,
        string document,
        DateTime birthDate,
        Email email,
        Address address)
    {
        Guard.Against.NullOrEmpty(name, nameof(name));
        Guard.Against.NullOrEmpty(document, nameof(document));
        Guard.Against.NullOrOutOfSQLDateRange(birthDate, nameof(birthDate), "User can't be under 18 years old");

        return new User(id, name, document, birthDate, email, address);
    }

    public void UpdateAddress(string street, string number, string city, string state, string country, string zipCode)
    {
        Address = Address.Of(street, number, city, state, country, zipCode);
    }
}
