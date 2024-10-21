using RentOCar.Users.Domain.ValueObjects;

namespace RentOCar.Users.Application.Commands.CreateUser;

public class CreateUserHandler : ICommandHandler<CreateUserCommand, CreateUserResponse>
{
    private readonly IUserRepository _userRepository;

    public CreateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<CreateUserResponse> Handle(
        CreateUserCommand command,
        CancellationToken cancellationToken)
    {
        var user = User.Create(
            Name.Of(command.FirstName, command.LastName),
            Document.Of(command.Document),
            command.BirthDate,
            Email.Of(command.Email),
            command.Phone,
            AddressDto.ToAddress(command.Address)
        );

        var newUser = await _userRepository.Create(user);

        return new CreateUserResponse(newUser.Id.Value);
    }
}
