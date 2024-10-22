namespace RentOCar.Users.Application.Commands.DeleteUser;

public sealed record DeleteUserCommand(Guid Id): ICommand<ResultViewModel>;
