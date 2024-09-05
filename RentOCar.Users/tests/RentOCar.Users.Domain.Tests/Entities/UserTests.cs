using Bogus;
using Bogus.Extensions.Brazil;

using BuildingBlocks.Exceptions;

using FluentAssertions;

namespace RentOCar.Users.Domain.Tests.Entities;

public sealed class UserTests
{
    private readonly Faker _faker = new("pt_BR");

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
        var action = () => MakeUser(birthDate: DateTime.Now.AddDays(3));

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void CreateUser_InvalidEmail_ShouldThrowInvalidEmailException()
    {
        var action = () => MakeUser(email: Email.Of(""));
        action.Should().Throw<InvalidEmailException>();
    }

    [Fact]
    public void CreateUser_InvalidDocument_ShouldThrowInvalidDocumentException()
    {
        var action = () => MakeUser(document: Document.Of(""));

        action.Should().Throw<InvalidDocumentException>();
    }

    private User MakeUser(
        Name? name = null,
        Document? document = null,
        DateTime? birthDate = null,
        Email? email = null,
        Address? address = null
    )
    {
        return User.Create(
            name ?? Name.Of(_faker.Person.FirstName, _faker.Person.LastName),
            document ?? Document.Of(_faker.Person.Cpf()),
            birthDate ?? _faker.Person.DateOfBirth,
            email ?? Email.Of(_faker.Person.Email),
            address ?? MakeAddress()
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
