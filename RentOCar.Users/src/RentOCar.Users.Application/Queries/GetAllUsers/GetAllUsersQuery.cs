namespace RentOCar.Users.Application.Queries.GetAllUsers;

public record GetAllUsersQuery() : IQuery<GetAllUsersResponse>;

public sealed record GetAllUsersResponse(List<UserOutputModel> Users);
