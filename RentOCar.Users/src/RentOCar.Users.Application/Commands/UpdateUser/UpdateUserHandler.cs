using RentOCar.Users.Domain.ValueObjects;

namespace RentOCar.Users.Application.Commands.UpdateUser;

public class UpdateUserHandler: ICommandHandler<UpdateUserCommand, UpdateUserResponse>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UpdateUserResponse> Handle(
        UpdateUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(UserId.Of(request.Id));
        if (user is null)
        {
            return new UpdateUserResponse(false);
        }

        user.Update(
            request.Telefone,
            AddressModel.ToAddress(request.Address)
        );

        await _userRepository.Update(user);

        return new UpdateUserResponse(true);
    }
}
