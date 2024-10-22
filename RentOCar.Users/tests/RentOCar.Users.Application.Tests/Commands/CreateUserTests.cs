using Bogus;
using Bogus.Extensions.Brazil;

using FluentAssertions;

using NSubstitute;
using NSubstitute.ExceptionExtensions;

using RentOCar.Users.Application.Commands.CreateUser;
using RentOCar.Users.Application.Models;
using RentOCar.Users.Domain.Interfaces;
using RentOCar.Users.Domain.ValueObjects;

namespace RentOCar.Users.Application.Tests.Commands;

public sealed class CreateUserTests
{
    private readonly Faker _faker = new Faker("pt_BR");

    [Fact]
    public void CreateUser_CommandHandlerCalled_ShouldReturnResponse()
    {
        var repositoryMock = Substitute.For<IUserRepository>();

        var handler = new CreateUserHandler(repositoryMock);

        handler.Handle(
                Arg.Any<CreateUserCommand>(),
                Arg.Any<CancellationToken>())
            .Should()
            .BeOfType<Task<ResultViewModel<CreateUserResponse>>>();
    }
}
