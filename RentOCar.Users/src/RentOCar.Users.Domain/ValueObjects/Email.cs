using BuildingBlocks.Extensions.GuardClauses;

namespace RentOCar.Users.Domain.ValueObjects;

public class Email: ValueObject
{
    public string Value { get; }

    private Email(string value) => Value = value;

    public static Email Of(string value)
    {
        Guard.Against.ValidEmail(value);
        return new Email(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
