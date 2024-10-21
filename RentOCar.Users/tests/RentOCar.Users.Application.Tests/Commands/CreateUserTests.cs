using Bogus;
using Bogus.Extensions.Brazil;

using RentOCar.Users.Application.Commands.CreateUser;
using RentOCar.Users.Domain.ValueObjects;

namespace RentOCar.Users.Application.Tests.Commands;

public sealed class CreateUserTests
{
    private readonly Faker _faker = new Faker("pt_BR");

    [Fact]
    public void CreateUser_CommandHandlerCalled_ShouldThrowException()
    {
        var userCommand = new CreateUserCommand(
            _faker.Person.FirstName,
            _faker.Person.LastName,
            _faker.Person.Cpf(),
            _faker.Person.DateOfBirth,
            _faker.Person.Phone,
            _faker.Person.Email,
            new AddressDto(
                _faker.Address.StreetName(),
                _faker.Address.BuildingNumber(),
                _faker.Address.City(),
                _faker.Address.State(),
                _faker.Address.Country(),
                _faker.Address.ZipCode())
        );
    }
}
