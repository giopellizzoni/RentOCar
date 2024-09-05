using Bogus;
using Bogus.Extensions.Brazil;

using FluentAssertions;

namespace RentOCar.Users.Domain.Tests.Entities;

public sealed class UserTests
{
    private readonly Faker _faker = new("pt_BR");

    [Theory]
    [InlineData("Name", "Document", "08/02/1986", "a@a.com")]
    [InlineData(null, "Document", "08/02/1986", "a@a.com")]
    [InlineData("Name", null, "08/02/1986", "a@a.com")]
    [InlineData("Name", "Document", null, "a@a.com")]
    [InlineData("Name", "Document", "08/02/1986", null)]
    public void CreateUser_InvalidInput_ThrowException(
        string name,
        string document,
        DateTime birthDate,
        string email)
    {
        Action action = () => User.Create(
            UserId.Of(Guid.Empty),
            name,
            document,
            birthDate,
            Email.Of(email),
            Address.Of(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
        );

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    private void CreateUser_ValidInput_ReturnUserCreated()
    {
        Action action = () => MakeUser();

        action.Should().NotThrow();
    }

    [Theory]
    [InlineData(null, "75", "City ", "State", "Country", "66019")]
    [InlineData("Street", null, "City", "State", "Country", "66019")]
    [InlineData("Street", "75", null, "State", "Country", "66019")]
    [InlineData("Street", "75", "City", null, "Country", "66019")]
    [InlineData("Street", "75", "City", "State", null, "66019")]
    [InlineData("Street", "75", "City", "State", "Country", null)]
    public void UpdateUserAddress_InvalidInputs_ThrowAnException(
        string street,
        string number,
        string city,
        string state,
        string country,
        string zipCode)
    {
        var user = MakeUser();
        var action = () => user.UpdateAddress(street, number, city, state, country, zipCode);

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void UpdateUserAddress_ValidInputs_UpdateUserSuccessfully()
    {
        var user = MakeUser();
        var oldAddress = user.Address;
        var newAddress = MakeAddress();

        user.UpdateAddress(
            newAddress.Street,
            newAddress.Number,
            newAddress.City,
            newAddress.State,
            newAddress.Country,
            newAddress.ZipCode);

        oldAddress.Should().NotBeSameAs(user.Address);
    }

    private User MakeUser()
    {
        return User.Create(
            UserId.Of(Guid.NewGuid()),
            _faker.Person.FullName,
            _faker.Person.Cpf(),
            _faker.Person.DateOfBirth,
            Email.Of(_faker.Person.Email),
            MakeAddress()
        );
    }

    private Address MakeAddress()
    {
        return Address.Of(
            _faker.Address.StreetName(),
            _faker.Address.BuildingNumber(),
            _faker.Address.City(),
            _faker.Address.State(),
            _faker.Address.Country(),
            _faker.Address.ZipCode());
    }
}
