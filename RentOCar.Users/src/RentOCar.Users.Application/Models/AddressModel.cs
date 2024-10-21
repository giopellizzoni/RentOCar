using RentOCar.Users.Domain.ValueObjects;

namespace RentOCar.Users.Application.Models;

public record AddressModel
{
    public string Street { get; set; }

    public string Number { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string Country { get; set; }

    public string ZipCode { get; set; }

    public AddressModel(
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

    public static AddressModel FromAddress(Address address)
    {
        return new AddressModel(
            address.Street,
            address.Number,
            address.City,
            address.State,
            address.Country,
            address.ZipCode
        );
    }

    public static Address ToAddress(AddressModel addressModel)
    {
        return Address.Of(
            addressModel.Street,
            addressModel.Number,
            addressModel.City,
            addressModel.State,
            addressModel.Country,
            addressModel.ZipCode);
    }
}
