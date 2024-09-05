namespace RentOCar.Users.Domain.ValueObjects;

public class Name: ValueObject
{
    public string FirstName { get; }

    public string LastName { get; }

    private Name(string firstName,
        string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public static Name Of(
        string firstName,
        string lastName)
    {
        Guard.Against.NullOrWhiteSpace(firstName, nameof(firstName), "First name can't be null");
        Guard.Against.NullOrWhiteSpace(lastName, nameof(lastName), "Last name can't be null");

        return new Name(firstName, lastName);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
    }
}
