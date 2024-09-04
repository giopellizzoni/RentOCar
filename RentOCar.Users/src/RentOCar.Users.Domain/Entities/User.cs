namespace RentOCar.Users.Domain.Entities;

public class User: Entity<UserId>
{
    public string  Name { get; private set; }

    public string Document { get; private set; }

    public DateTime BirthDate { get; private set; }

    public Email Email { get; set; }

}
