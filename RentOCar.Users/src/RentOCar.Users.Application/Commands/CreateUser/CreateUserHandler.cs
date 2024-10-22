namespace RentOCar.Users.Application.Commands.CreateUser;

public class CreateUserHandler : ICommandHandler<CreateUserCommand, ResultViewModel<CreateUserResponse>>
{
    private readonly IUserRepository _userRepository;

    public CreateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ResultViewModel<CreateUserResponse>> Handle(
        CreateUserCommand command,
        CancellationToken cancellationToken)
    {
        var user = User.Create(
            Name.Of(command.FirstName, command.LastName),
            Document.Of(command.Document),
            command.BirthDate,
            Email.Of(command.Email),
            command.Phone,
            AddressModel.ToAddress(command.Address)
        );

        await _userRepository.Create(user);

        var response = new CreateUserResponse(user.Id.Value);

        return ResultViewModel<CreateUserResponse>.Success(response);

    }
}
