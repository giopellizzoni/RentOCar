using BuildingBlocks.Repository;

using RentOCar.Users.Domain.Entities;

namespace RentOCar.Users.Domain.Interfaces;

public interface IUserRepository: IRepository<User, UserId>
{

}
