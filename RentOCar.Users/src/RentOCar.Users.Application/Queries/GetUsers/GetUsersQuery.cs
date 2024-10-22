namespace RentOCar.Users.Application.Queries.GetUsers;

public record GetUsersQuery(string Search) : IQuery<ResultViewModel<GetUsersResponse>>;

public sealed record GetUsersResponse(List<UserOutputModel> Users);
