using Bogus;
using Bogus.Extensions.Brazil;

using BuildingBlocks.Exceptions;

using FluentAssertions;

namespace RentOCar.Users.Domain.Tests.Entities;

public sealed class UserTests
{
    private readonly Faker _faker = new("pt_BR");

    [Theory]
    [InlineData("Name", "Last", "11122233344", "08/02/1986", "a@a.com")]
    [InlineData(null, "Last", "11122233344", "08/02/1986", "a@a.com")]
    [InlineData("Name", null, "11122233344", "08/02/1986", "a@a.com")]
    [InlineData("Name", "Last", null, "08/02/1986", "a@a.com")]
    [InlineData("Name", "Last", "11122233344", null, "a@a.com")]
    [InlineData("Name", "Last", "11122233344", "08/02/1986", null)]
    public void CreateUser_InvalidInput_ThrowException(
        string firstName,
        string lastName,
        string document,
        DateTime birthDate,
        string email)
    {
        Action action = () => User.Create(
            UserId.Of(Guid.Empty),
            Name.Of(firstName, lastName),
            Document.Of(document),
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

        var action = () =>
        {
            var address = Address.Of(street, number, city, state, country, zipCode);
            user.UpdateAddress(address);
        };

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void UpdateUserAddress_ValidInputs_UpdateUserSuccessfully()
    {
        var user = MakeUser();
        var oldAddress = user.Address;
        var newAddress = MakeAddress();

        user.UpdateAddress(newAddress);

        oldAddress.Should().NotBeSameAs(user.Address);
    }

    [Fact]
    public void CreateUser_DateInFuture_ShouldThrowException()
    {
        var address = MakeAddress();
        var action = () => User.Create(
            UserId.Of(Guid.NewGuid()),
            Name.Of(_faker.Person.FirstName, _faker.Person.LastName),
            Document.Of(_faker.Person.Cpf()),
            DateTime.Now.AddDays(3),
            Email.Of(_faker.Person.Email),
            address);

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void CreateUser_InvalidEmail_ShouldThrowInvalidEmailException()
    {
        var address = MakeAddress();
        var action = () => User.Create(
            UserId.Of(Guid.NewGuid()),
            Name.Of(_faker.Person.FirstName, _faker.Person.LastName),
            Document.Of(_faker.Person.Cpf()),
            DateTime.Now.AddDays(3),
            Email.Of(""),
            address);

        action.Should().Throw<InvalidEmailException>();
    }

    [Fact]
    public void CreateUser_InvalidDocument_ShouldThrowInvalidDocumentException()
    {
        var address = MakeAddress();
        var action = () => User.Create(
            UserId.Of(Guid.NewGuid()),
            Name.Of(_faker.Person.FirstName, _faker.Person.LastName),
            Document.Of(""),
            DateTime.Now.AddDays(3),
            Email.Of(""),
            address);
        action.Should().Throw<InvalidDocumentException>();
    }

    private User MakeUser()
    {
        return User.Create(
            UserId.Of(Guid.NewGuid()),
            Name.Of(_faker.Person.FirstName, _faker.Person.LastName),
            Document.Of(_faker.Person.Cpf()),
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
