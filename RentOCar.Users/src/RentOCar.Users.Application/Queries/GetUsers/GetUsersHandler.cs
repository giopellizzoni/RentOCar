namespace RentOCar.Users.Application.Queries.GetUsers;

public class GetUsersHandler : IQueryHandler<GetUsersQuery, ResultViewModel<GetUsersResponse>>
{
    private readonly IUserRepository _userRepository;

    public GetUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ResultViewModel<GetUsersResponse>> Handle(
        GetUsersQuery request,
        CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAll(request.Search);

        var usersOutput = users.Select(UserOutputModel.FromUser).ToList();
        var response = new GetUsersResponse(usersOutput);

        return ResultViewModel<GetUsersResponse>.Success(response);
    }
}
