namespace RentOCar.Users.Application.Commands.CreateUser;

public sealed record CreateUserCommand(
    string FirstName,
    string LastName,
    string Document,
    DateTime BirthDate,
    string Email,
    string Phone,
    AddressModel Address) : ICommand<ResultViewModel<CreateUserResponse>>;

public sealed record CreateUserResponse(Guid Id);
