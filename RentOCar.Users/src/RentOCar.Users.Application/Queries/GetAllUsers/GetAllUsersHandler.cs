namespace RentOCar.Users.Application.Queries.GetAllUsers;

public class GetAllUsersHandler : IQueryHandler<GetAllUsersQuery, GetAllUsersResponse >
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetAllUsersResponse> Handle(
        GetAllUsersQuery request,
        CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAll();

        var usersOutput = users.Select(UserOutputModel.FromUser).ToList();

        return new GetAllUsersResponse(usersOutput);
    }
}
