using RentOCar.Users.Domain.Interfaces;
using RentOCar.Users.Domain.ValueObjects;
using RentOCar.Users.Infrastructure.Context;

namespace RentOCar.Users.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UsersDbContext _context;

    public UserRepository(UsersDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetById(UserId id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        return user;
    }

    public async Task<List<User>> GetAll(string? search)
    {
        var users = await _context.Users
            .Where(u => search != null && u.Name.FirstName.Contains(search))
            .ToListAsync();

        return users;
    }

    public async Task Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User> Create(User user)
    {
        var newUser = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return newUser.Entity;
    }

    public async Task Delete(User user)
    {
        user.Delete();
        await _context.SaveChangesAsync();
    }
}
