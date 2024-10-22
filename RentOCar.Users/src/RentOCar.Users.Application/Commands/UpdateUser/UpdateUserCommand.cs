namespace RentOCar.Users.Application.Commands.UpdateUser;

public record UpdateUserCommand(Guid Id, string Telefone, AddressModel Address) : ICommand<ResultViewModel>;

