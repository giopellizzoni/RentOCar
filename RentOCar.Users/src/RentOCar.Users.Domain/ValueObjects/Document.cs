using BuildingBlocks.Extensions.GuardClauses;

namespace RentOCar.Users.Domain.ValueObjects;

public class Document : ValueObject
{
    public string Value { get; private set; }

    private Document(string value)
    {
        Value = value;
    }

    public static Document Of(string value)
    {
        Guard.Against.ValidDocument(value, nameof(value));

        return new Document(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
