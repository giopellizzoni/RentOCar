namespace RentOCar.Users.Application.Commands.DeleteUser;

public class DeleteUserHandler: ICommandHandler<DeleteUserCommand, ResultViewModel>
{
    private readonly IUserRepository _repository;

    public DeleteUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel> Handle(
        DeleteUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _repository.GetById(UserId.Of(request.Id));
        if(user is null)
        {
            return ResultViewModel.Error("User not found");
        }

        await _repository.Delete(user);

        return ResultViewModel.Success();
    }
}
