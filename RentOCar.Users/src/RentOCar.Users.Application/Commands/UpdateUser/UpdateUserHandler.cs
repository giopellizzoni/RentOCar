namespace RentOCar.Users.Application.Commands.UpdateUser;

public class UpdateUserHandler: ICommandHandler<UpdateUserCommand, ResultViewModel>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ResultViewModel> Handle(
        UpdateUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(UserId.Of(request.Id));
        if (user is null)
        {
            var response = ResultViewModel.Error("Could not find user with the given id");
            return response;
        }

        user.Update(
            request.Telefone,
            AddressModel.ToAddress(request.Address)
        );

        await _userRepository.Update(user);

        return ResultViewModel.Success();
    }
}
