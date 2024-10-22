namespace RentOCar.Users.Application.Queries.GetUserById;

public sealed record GetUserByIdQuery(Guid Id) : IQuery<ResultViewModel<GetUserByIdResponse>>;

public sealed record GetUserByIdResponse(UserOutputModel User);
