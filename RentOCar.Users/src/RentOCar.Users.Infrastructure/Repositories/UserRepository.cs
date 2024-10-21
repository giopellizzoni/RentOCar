using RentOCar.Users.Domain.Interfaces;
using RentOCar.Users.Domain.ValueObjects;
using RentOCar.Users.Infrastructure.Context;

namespace RentOCar.Users.Infrastructure.Repositories;

public class UserRepository: IUserRepository
{

    private readonly UsersDbContext _context;

    public UserRepository(UsersDbContext context)
    {
        _context = context;
    }

    public Task<User?> GetById(UserId id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<User>> GetAll()
    {
        var users = await _context.Users.ToListAsync();
        return users;
    }

    public Task Update(User t)
    {
        throw new NotImplementedException();
    }

    public async Task<User> Create(User user)
    {
        var newUser = await _context.Users.AddAsync(user);
        return newUser.Entity;
    }

    public Task Delete(UserId id)
    {
        throw new NotImplementedException();
    }
}
