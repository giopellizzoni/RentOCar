namespace RentOCar.Users.Domain.ValueObjects;

public class UserId : ValueObject
{
    public Guid Value { get; }

    private UserId(Guid value) => Value = value;

    public static UserId Of(Guid value)
    {
        Guard.Against.NullOrEmpty(value, nameof(value), "User Id can't be null");

        return new UserId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
