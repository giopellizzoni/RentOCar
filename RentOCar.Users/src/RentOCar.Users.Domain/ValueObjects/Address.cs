namespace RentOCar.Users.Domain.ValueObjects;

public class Address : ValueObject
{
    public string Street { get; }

    public string Number { get; }

    public string City { get; }

    public string State { get; }

    public string Country { get; }

    public string ZipCode { get; }

    private Address(
        string street,
        string number,
        string city,
        string state,
        string country,
        string zipCode)
    {
        Street = street;
        Number = number;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
    }

    public static Address Of(
        string street,
        string number,
        string city,
        string state,
        string country,
        string zipCode)
    {
        Guard.Against.NullOrWhiteSpace(street, nameof(street), "Address can't be empty");
        Guard.Against.NullOrWhiteSpace(number, nameof(number), "Number can't be empty");
        Guard.Against.NullOrWhiteSpace(city, nameof(city), "City can't be empty");
        Guard.Against.NullOrWhiteSpace(state, nameof(state), "State can't be empty");
        Guard.Against.NullOrWhiteSpace(country, nameof(country), "Country can't be empty");
        Guard.Against.NullOrWhiteSpace(zipCode, nameof(zipCode), "ZipCode can't be empty");

        return new Address(street, number, city, state, country, zipCode);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return Number;
        yield return City;
        yield return State;
        yield return Country;
        yield return ZipCode;
    }
}
