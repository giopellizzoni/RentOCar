using RentOCar.Users.Domain.ValueObjects;

namespace RentOCar.Users.Application.Models;

public record AddressOutputModel
{
    public string Street { get; set; }

    public string Number { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string Country { get; set; }

    public string ZipCode { get; set; }

    public AddressOutputModel(
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

    public static AddressOutputModel FromAddress(Address address)
    {
        return new AddressOutputModel(
            address.Street,
            address.Number,
            address.City,
            address.State,
            address.Country,
            address.ZipCode
        );
    }
}
