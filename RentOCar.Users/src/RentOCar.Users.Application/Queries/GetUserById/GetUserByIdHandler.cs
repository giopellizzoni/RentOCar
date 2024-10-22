namespace RentOCar.Users.Application.Queries.GetUserById;

public class GetUserByIdHandler: IQueryHandler<GetUserByIdQuery, ResultViewModel<GetUserByIdResponse>>
{
    private readonly IUserRepository _repository;

    public GetUserByIdHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<GetUserByIdResponse>> Handle(
        GetUserByIdQuery request,
        CancellationToken cancellationToken)
    {
        var user = await _repository.GetById(UserId.Of(request.Id));
        if(user == null)
        {
            return ResultViewModel<GetUserByIdResponse>.Error("User not found");
        }

        var response = new GetUserByIdResponse(UserOutputModel.FromUser(user));

        return ResultViewModel<GetUserByIdResponse>.Success(response);
    }
}
