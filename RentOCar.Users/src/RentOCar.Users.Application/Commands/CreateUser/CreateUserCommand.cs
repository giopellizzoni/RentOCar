using RentOCar.Users.Domain.ValueObjects;

namespace RentOCar.Users.Application.Commands.CreateUser;

public record CreateUserCommand(
    string FirstName,
    string LastName,
    string Document,
    DateTime BirthDate,
    string Email,
    AddressDto Address) : ICommand<CreateUserResponse>;

public sealed record CreateUserResponse(Guid Id);

public record AddressDto(
    string Street,
    string Number,
    string City,
    string State,
    string Country,
    string ZipCode
)
{
    public static Address ToAddress(AddressDto dto)
    {
        return Address.Of(dto.Street, dto.Number, dto.City, dto.State, dto.Country, dto.ZipCode);
    }
}
